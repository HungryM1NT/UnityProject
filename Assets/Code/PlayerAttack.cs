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

    void Update()
    {
        if(timeBtwAttack <= 0f)
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

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        timeBtwAttack = startTimeBtwAttack;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
