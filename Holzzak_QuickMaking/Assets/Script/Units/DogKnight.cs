using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogKnight : Unit
{
    private void Start()
    {
        level = 2;
        attackPoint = 2;
    }

    private void Update()
    {
        if (GameManager.instance.bPlayerUnitMove)
        {
            MoveForward();
        }
    }

}
