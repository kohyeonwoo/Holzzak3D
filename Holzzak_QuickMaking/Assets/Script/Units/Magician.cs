using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : Unit
{
    private void Start()
    {
        level = 4;
        attackPoint = 4;
    }

    private void Update()
    {
        if (GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }
    }
}
