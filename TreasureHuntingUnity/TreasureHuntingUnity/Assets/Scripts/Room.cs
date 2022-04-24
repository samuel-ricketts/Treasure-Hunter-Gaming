/*
 * Created by: Krieger
 * Created on: 4/23/2022
 * 
 * Last Edited By: Krieger
 * Last Edited On: 4/23/2022
 * 
 * Description: Controls enemies in a room
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    /***VARIABLES***/

    [Header("Enemies")]
    public int startingEnemies = 3;
    public int maxEnemies = 6;
    public float timeToEnemySpawn = 3f;
    public GameObject[] enemyPrefabs; //array containing all the enemy prefabs that can spawn in the room
    [Space(10)]
    [SerializeField]
    private List<GameObject> currentEnemies; //list of all enemies currently spawned in the room

    public float enemySpawnAreaHeight = 30f;
    public float enemySpawnAreaWidth = 60f;

    private bool invokedSpawn = false;

    [Header("Player")]
    [SerializeField]
    private bool playerInRoom = false; //if the player is currently in the room
    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentEnemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //when the player enters
    {
        if(playerInRoom) { return; } //if the player is already in the room it doesn't matter

        GameObject go = other.gameObject; 

        if(go.tag == "Player")
        {
            playerInRoom = true;
            player = go;

            if (currentEnemies.Count == 0) //spawn the starting number of enemies
            {
                for (int index = 0; index < startingEnemies; index++)
                {
                    SpawnEnemy();
                    invokedSpawn = true;
                }
            }

        }
    }

    private void OnTriggerExit(Collider other) //when the player exits
    {
        if (!playerInRoom) { return; } //if the player is not already in the room it doesn't matter

        GameObject go = other.gameObject; 

        if (go.tag == "Player")
        {
            playerInRoom = false;
            
        }
    }

    private void SpawnEnemy() //spawns an enemy from the list of prefabs, places it in the room, and adds it to the list of current enemies
    {
        if(playerInRoom && enemyPrefabs.Length != 0)
        {
            if (currentEnemies.Count < maxEnemies)
            {
                Vector3 enemyPos = transform.position;
                enemyPos.z = 0;
                enemyPos.x += Random.Range(-enemySpawnAreaWidth, enemySpawnAreaWidth);
                enemyPos.y += Random.Range(-enemySpawnAreaHeight, enemySpawnAreaHeight);

                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject newEnemy = Instantiate<GameObject>(enemyPrefabs[enemyIndex]);
                newEnemy.transform.position = enemyPos;

                currentEnemies.Add(newEnemy);

                Enemy nme = newEnemy.GetComponent<Enemy>();
                if (nme != null)
                {
                    nme.SetTarget(player);
                }
            }

            if (!invokedSpawn)
            {
                Invoke("SpawnEnemy", timeToEnemySpawn);
            }
        }
        
    }
}
