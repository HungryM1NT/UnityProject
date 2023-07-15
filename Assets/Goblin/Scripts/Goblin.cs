using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Goblin : MonoBehaviour
{
    public float speed;
    public int damage;
    private Transform player;
    public float agroDistance;
    public Animator animator;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if ((distToPlayer < agroDistance) && (distToPlayer > 0.9))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (distToPlayer < 0.9 && timeBtwAttack <= 0f)
        {
            animator.SetTrigger("Attack");
            switch (AttackDir())
            {
                case "x":
                    animator.SetFloat("AttackDir", 0);
                    timeBtwAttack = startTimeBtwAttack;
                    break;
                case "up":
                    animator.SetFloat("AttackDir", 1);
                    timeBtwAttack = startTimeBtwAttack;
                    break;
                case "down":
                    animator.SetFloat("AttackDir", -1);
                    timeBtwAttack = startTimeBtwAttack;
                    break;
            }
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else
            timeBtwAttack -= Time.deltaTime;
    }

    string AttackDir()
    {
        float xPos = player.position.x - transform.position.x;
        float yPos = player.position.y - transform.position.y;
        string dir;
        if (Mathf.Abs(xPos) >= Mathf.Abs(yPos))
        {
            dir = "x";
        }
        else
        {
            if (yPos >= 0f)
            {
                dir = "up";
            }
            else
                dir = "down";
        }
        return dir;
    }

}
