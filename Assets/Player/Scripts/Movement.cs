using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float Speed = 6;           // Глобальная переменная скорость персонажа
    private Rigidbody2D rb;            // Переменная для работы с объектом
    private Vector2 direction;
    public Animator animator;
    //private bool looksRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // Привязка rb к Rigidbody2D
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");     // Переменная, отвечающая за горизонтальное передвижение
        direction.y = Input.GetAxisRaw("Vertical");       // Переменная, отвечающая за вертикальное передвижение

        if (direction.x != 0)
            animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);   // Перемещение персонажа от x и y
    }

}