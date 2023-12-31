using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public KeyCode attackRight;
    public KeyCode attackLeft;
    public KeyCode attackUp;
    public KeyCode attackDown;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;

    public GameObject pause;
    public GameObject swipe;
    public GameObject hit;

    int hitCount = 0;
    int count = 0;

    void Update()
    {
        if (!pause.activeInHierarchy)
        {
            if (timeBtwAttack <= 0f)
            {
                if (Input.GetKeyDown(attackLeft))
                {
                    anim.SetTrigger("Attack");
                    anim.SetFloat("Attack_dir", 1);
                }
                else if (Input.GetKeyDown(attackUp))
                {
                    anim.SetTrigger("Attack");
                    anim.SetFloat("Attack_dir", 2);
                }
                else if (Input.GetKeyDown(attackRight))
                {
                    anim.SetTrigger("Attack");
                    anim.SetFloat("Attack_dir", 3);
                }
                else if (Input.GetKeyDown(attackDown))
                {
                    anim.SetTrigger("Attack");
                    anim.SetFloat("Attack_dir", 4);
                }
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
            if(hitCount == 0)
            {
                Instantiate(hit, transform.position, Quaternion.identity);
            }
            hitCount++;
        }
        timeBtwAttack = startTimeBtwAttack;
        if(count == 0)
        {
            Instantiate(swipe, transform.position, Quaternion.identity);
        }
        count++;
        if(count == 3)
        {
            count = 0;
            hitCount = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
