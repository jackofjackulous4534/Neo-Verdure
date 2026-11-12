using System.Collections;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{
    [SerializeField] float attackTime = 0.05f;
    [SerializeField] float coolDown = 0.1f;
    
    [SerializeField] GameObject attackBox;
    IEnumerator Hit()
    {
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        attackBox.SetActive(false);
    }
}
