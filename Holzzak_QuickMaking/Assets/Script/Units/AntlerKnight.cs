using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntlerKnight : Unit
{
    private void Start()
    {
        level = 5;
        attackPoint = 5;
    }

    private void Update()
    {
        if (GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }
    }
}
