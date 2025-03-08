using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Unit
{
    private void Start()
    {
        level = 1;
        attackPoint = 3;
    }

    private void Update()
    {

        if (GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }

        if (GameManager.instance.bPlayerUnitDestroy == true)
        {
            Dead();
        }

    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }

}
