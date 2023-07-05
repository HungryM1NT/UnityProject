using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
