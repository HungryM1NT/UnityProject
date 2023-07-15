using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float Speed = 6;           // ���������� ���������� �������� ���������
    private Rigidbody2D rb;            // ���������� ��� ������ � ��������
    private Vector2 direction;
    public Animator animator;

    public GameObject pause;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // �������� rb � Rigidbody2D
    }

    void Update()
    {
        if (!pause.activeInHierarchy)
        {
            direction.x = Input.GetAxisRaw("Horizontal");     // ����������, ���������� �� �������������� ������������
            direction.y = Input.GetAxisRaw("Vertical");       // ����������, ���������� �� ������������ ������������

            if (direction.x != 0)
                animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);   // ����������� ��������� �� x � y
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Stairs"))
        {
            SceneManager.LoadScene(3);
        }
    }

}