using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public Transform target;

    //[SerializeField]
    //private string targetTag = "Unit";

    protected Animator animator;
   // private Rigidbody rigid;
    
   // private float speed;

    //[SerializeField]
    //private float range = 7.5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //rigid = GetComponent<Rigidbody>();

       // speed = 2.0f;
    }

   

}
