using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_KnightAbility : Unit
{
    private float time = 2.0f;

    private void OnEnable()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(this.gameObject, time);
    }

}
