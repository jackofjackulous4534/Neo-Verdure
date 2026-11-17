using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float attackTime = 0.15f;
    [SerializeField] float coolDownDuration = 0.2f;
    private float startCooldownTime;
    private bool isAttacking;

    [SerializeField] HitBox attackBox;

    IEnumerator ActivateHitBox()
    {
        isAttacking = true;
        attackBox.StartAttack();
        yield return new WaitForSeconds(attackTime);
        attackBox.EndAttack();
        startCooldownTime = Time.time;
        isAttacking = false;
    }

    public void Hit()
    {
        if (CustomUtilities.HasTimeElapsed(startCooldownTime, coolDownDuration) && !isAttacking)
        {
            StartCoroutine(ActivateHitBox());
        }
    }
}
