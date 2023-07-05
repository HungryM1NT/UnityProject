using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFollow : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float agroDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
                Debug.Log("1");
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
                Debug.Log("2");
            }

        }
    }
}
