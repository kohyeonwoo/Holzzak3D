using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float maxHealth;
    protected float currentHealth;
    protected int attackPoint;
    protected int level;

    protected Animator anim;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Attack() { }
    public virtual void Die() { }


}
