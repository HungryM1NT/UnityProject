using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AddRoom : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject walleffect;
    public GameObject[] keyDoor;

    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;

    public List<GameObject> enemies;

    private RoomVariants variants;
    private bool spawned;
    private bool doorsOpened;

    public GameObject[] roomUnits;
    public GameObject stairs;
    public GameObject bossSpawner;

    private void Awake()
    {
        variants = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVariants>();
    }

    private void Start()
    {
        variants.rooms.Add(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !spawned)
        {
            spawned = true;
            if (!bossSpawner.activeInHierarchy)
            {
                foreach (Transform spawner in enemySpawners)
                {
                    GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                    GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject;
                    enemy.transform.parent = transform;
                    enemies.Add(enemy);
                }
            StartCoroutine(CheckEnemies());
            }
        }
    }

    IEnumerator CheckEnemies()
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        if (!bossSpawner.activeInHierarchy)
        {
            OpenDoors();
        }
    }

    public void OpenDoors()
    {
        foreach (GameObject door in doors)
        {
            if (door != null && door.transform.childCount != 0)
            {
                Instantiate(walleffect, door.transform.position, Quaternion.identity);
                Destroy(door);
            }
        }
        doorsOpened = true;
    }
}
