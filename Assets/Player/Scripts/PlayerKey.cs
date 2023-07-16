using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    public GameObject keyIcon;
    public GameObject wallEffect;
    public GameObject keyPickup;
    public GameObject keyDoorOpen;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Key"))
        {
            keyIcon.SetActive(true);
            Destroy(other.gameObject);
            Instantiate(keyPickup, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("KeyDoor") && keyIcon.activeInHierarchy)
        {
            Instantiate(wallEffect, other.transform.position, Quaternion.identity);
            keyIcon.SetActive(false);
            other.gameObject.SetActive(false);
            Instantiate(keyDoorOpen, transform.position, Quaternion.identity);
        }
    }
}
