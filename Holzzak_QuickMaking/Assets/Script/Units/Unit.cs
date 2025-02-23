using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Transform target;

    [SerializeField]
    private string targetTag = "Enemy";

    protected float maxHealth;
    protected float currentHealth;
    protected int attackPoint;
    protected int level;

    [SerializeField]
    private float range = 7.5f;

    protected Animator anim;
    protected Rigidbody rigid;
    
    protected void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
    }

    public virtual void Attack() { }

    public void MoveForward()
    {
        anim.SetBool("bMove", true);
        transform.Translate(Vector3.forward * 0.125f);
    }

    private void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        float shortestDistance = Mathf.Infinity; //�� ���� �����Ǿ� ���� ���� ���

        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;

                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    public virtual void Heal() { }

    public virtual void Die() { }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Opposite")
        {
            Destroy(this.gameObject);
            GameManager.instance.enemyHealth -= attackPoint;
            GameManager.instance.EnemyHandleHP();
        }
    }

}
