using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Commissar : Player
{

    public GameObject bolter;

    public void Attack()
    {
        animator.SetBool("bAbility1", true);
    }

    public void AttackEnd()
    {
        animator.SetBool("bAbility1", false);
    }

    public void ActiveBolter()
    {
        bolter.SetActive(true);
    }

    public void DeActiveBolter()
    {
        bolter.SetActive(false);
    }

}
