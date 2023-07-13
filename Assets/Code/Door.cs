using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject wall;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            Instantiate(wall, transform.GetChild(0).position, Quaternion.identity);
            Destroy(gameObject);
        }
    }    
}
