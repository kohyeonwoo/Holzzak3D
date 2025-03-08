using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float maxHealth;
    protected float currentHealth;
    protected int attackPoint;
    protected int level;

    protected Animator anim;
    protected Rigidbody rigid;

    public GameObject hitParticle;
    public Transform hitLocation;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    public virtual void Attack() { }

    public void MoveForward()
    {
        anim.SetBool("bMove", true);
        transform.Translate(Vector3.forward * 0.125f);
    }

    public virtual void Die() { }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject obj = Instantiate(hitParticle, hitLocation.position, Quaternion.identity);
            Destroy(obj, 2.0f);

            Destroy(this.gameObject);
            GameManager.instance.health -= attackPoint;
            GameManager.instance.HandleHp();
            AudioManager.Instance.PlaySFX("PlayerHitSound");
            GameManager.instance.bShake = true;
  
        }

        if (collision.gameObject.tag == "Unit")
        {
            AudioManager.Instance.PlaySFX("CollisionSound");
            GameObject obj = Instantiate(hitParticle, hitLocation.position, Quaternion.identity);
            Destroy(obj, 2.0f);

            Destroy(this.gameObject);
        }
    }
}
