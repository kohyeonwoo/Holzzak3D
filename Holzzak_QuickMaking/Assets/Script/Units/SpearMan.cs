using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMan : Unit
{
    private void Start()
    {
        level = 3;
        attackPoint = 3;
    }

    private void Update()
    {
        if (GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }
    }

}
