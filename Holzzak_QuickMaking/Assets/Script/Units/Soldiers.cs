using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamType { Team1, Team2}

public class Soldiers : MonoBehaviour, IDamageable
{

    public TeamType teamType;

    public float maxHealth;

    public float currentHealth;

    public float bulletSpeed;

    public float speed;

    public GameObject bulletPrefab;

    public Transform muzzleLocation;

    private Animator anim;

    private Rigidbody rigid;

    int randNumber;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        rigid = GetComponent<Rigidbody>();

        currentHealth = maxHealth;

        randNumber = 0;
    }

    public void Attack()
    {
        randNumber = Random.Range(0, 2);


        if(randNumber == 0)
        {
            //anim.SetBool("bMove", true);
            //rigid.AddForce(Vector3.forward * speed);
            return;
        }
        else if(randNumber == 1)
        {
            anim.SetBool("bAttack", true);
            Shoot();
        }
     
      
    }

    public void AttackFalse()
    {
        anim.SetBool("bAttack", false);
    }

    public void Shoot()
    {
        Debug.Log("총알 발사");
        AudioManager.Instance.PlaySFX("RifleShotSound");

        GameObject bullets = Instantiate(bulletPrefab, muzzleLocation.position, muzzleLocation.rotation);
        bullets.GetComponent<Rigidbody>().velocity = muzzleLocation.transform.forward * bulletSpeed;
    }

    public void Damage(float Damage)
    {
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        anim.SetBool("bDead", true);

        if(teamType == TeamType.Team1)
        {
            GameManager.instance.team1DeadCount++;
        }
        else if(teamType == TeamType.Team2)
        {
            GameManager.instance.team2DeadCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
              anim.SetBool("bDead", true);
              Debug.Log("서로 부딫혔다!!!");   
        }
    }
}
