using System.Collections;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float attackTime = 0.15f;
    [SerializeField] float coolDownDuration = 0.2f;
    private float startCooldownTime;
    private bool isAttacking;

    [SerializeField] GameObject attackBox;

    IEnumerator ActivateHitBox()
    {
        isAttacking = true;
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        attackBox.SetActive(false);
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
