using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVariants : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject[] startRooms;

    public GameObject key;

    [HideInInspector] public List<GameObject> rooms;

    private void Start()
    {
        StartCoroutine(RandomSpawner());
    }

    IEnumerator RandomSpawner()
    {
        yield return new WaitForSeconds(30f);
        AddRoom lastRoom = rooms[rooms.Count - 1].GetComponent<AddRoom>();
        int rand = Random.Range(0, rooms.Count - 1);
        Vector3 pos = rooms[rand].transform.position;
        pos[0] += 0.5f;
        pos[1] += 0.5f;
        Instantiate(key, pos, Quaternion.identity);

        lastRoom.keyDoor.SetActive(true);
        lastRoom.OpenDoors();
    }
}
