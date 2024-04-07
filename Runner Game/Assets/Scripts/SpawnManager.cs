using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float spawnRate = 2.5f;
    private PlayerController playerControllerscript;

    // Start is called before the first frame update
    void Start()
    {
        //get player controller script
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerController>();
        //spawn obstacle according to the spawn rate
        InvokeRepeating("SpawnObstacle", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn the obstacle while game is not over
    void SpawnObstacle()
    {
        if (!playerControllerscript.gameOver && playerControllerscript.gameStart)
        {
            int index = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[index], spawnPos, obstaclePrefab[index].transform.rotation);
        }
        
    }
}
