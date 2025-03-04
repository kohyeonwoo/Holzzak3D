using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnight : Player
{
    public void Attack()
    {
        animator.SetBool("bAttack", true);
    }

    public void AttackEnd()
    {
        animator.SetBool("bAttack", false);
    }
}
