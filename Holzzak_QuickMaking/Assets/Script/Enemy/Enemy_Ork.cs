using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ork : Enemy
{
    private void Start()
    {
        this.transform.localRotation = Quaternion.Euler(0, -90, 0);
    }
}
