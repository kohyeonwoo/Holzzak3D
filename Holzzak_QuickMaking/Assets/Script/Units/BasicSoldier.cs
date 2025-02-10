using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSoldier : Unit
{

    private void Start()
    {
        attackPoint = 1;
    }

    private void Update()
    {
        if(GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }
    }

}
