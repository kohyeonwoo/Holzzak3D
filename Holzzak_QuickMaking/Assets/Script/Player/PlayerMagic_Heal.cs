using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic_Heal : PlayerMagic
{
    private void CheckForColliders()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4.0f);

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<Unit>())
            {
              
            }
        }
    }
}
