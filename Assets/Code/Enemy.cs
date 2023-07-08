using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    private Rigidbody2D rb;
    public GameObject effect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        rb.Sleep();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
