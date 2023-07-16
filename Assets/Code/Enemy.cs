using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private Rigidbody2D rb;
    public GameObject effect;
    private AddRoom room;
    public GameObject goblinDeath;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        room = GetComponentInParent<AddRoom>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            room.enemies.Remove(gameObject);
            if (gameObject.name == "Goblin(Clone)")
            {
                Instantiate(goblinDeath, transform.position, Quaternion.identity);
            }
        }
        rb.Sleep();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
