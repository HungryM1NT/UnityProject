using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float Speed = 6;           // ���������� ���������� �������� ���������
    private Rigidbody2D rb;            // ���������� ��� ������ � ��������
    private Vector2 direction;
    public Animator animator;
    //private bool looksRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // �������� rb � Rigidbody2D
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");     // ����������, ���������� �� �������������� ������������
        direction.y = Input.GetAxisRaw("Vertical");       // ����������, ���������� �� ������������ ������������

        if (direction.x != 0)
            animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);   // ����������� ��������� �� x � y
    }

}