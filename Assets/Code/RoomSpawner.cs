using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RoomSpawner : MonoBehaviour
{
    public Direction direction;

    public enum Direction
    {
        Top,
        Bottom,
        Left,
        Right,
        All,
        None
    }

    private RoomVariants variants;
    private int rand;
    private bool spawned = false;
    private float waitTime = 120f;

    private void Start()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        if(!spawned)
        {
            if (direction == Direction.Top)
            {
                Invoke("SpawnTop", 0f);
            }
            else if (direction == Direction.Bottom)
            {
                Invoke("SpawnBottom", 0.2f);
            }
            else if (direction == Direction.Left)
            {
                Invoke("SpawnLeft", 0.3f);
            }
            else if (direction == Direction.Right)
            {
                Invoke("SpawnRight", 0.5f);
            }
            else if (direction == Direction.All)
            {
                rand = Random.Range(0, variants.startRooms.Length);
                Instantiate(variants.startRooms[rand], transform.position, variants.startRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned)
        { 
            Destroy(gameObject);
        }
        
    }

    private void SpawnTop()
    {
        rand = Random.Range(0, variants.topRooms.Length);
        Instantiate(variants.topRooms[rand], transform.position, variants.topRooms[rand].transform.rotation);
    }

    private void SpawnBottom()
    {
        rand = Random.Range(0, variants.bottomRooms.Length);
        Instantiate(variants.bottomRooms[rand], transform.position, variants.bottomRooms[rand].transform.rotation);
    }

    private void SpawnRight()
    {
        rand = Random.Range(0, variants.rightRooms.Length);
        Instantiate(variants.rightRooms[rand], transform.position, variants.rightRooms[rand].transform.rotation);
    }

    private void SpawnLeft()
    {
        rand = Random.Range(0, variants.leftRooms.Length);
        Instantiate(variants.leftRooms[rand], transform.position, variants.leftRooms[rand].transform.rotation);
    }
}
