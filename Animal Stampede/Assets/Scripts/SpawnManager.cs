using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZTop = 15;
    private float spawnRangeZBottom = 0;
    private float startDelay = 2;
    private float spawnInterval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //generte animal prefabs in fixed intervals 
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void SpawnRandomAnimal()
    {
        //select random animal to generate
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos;

        //randomly pick front or side
        int frontOrSide = Random.Range(0, 2);
        if (frontOrSide == 0)
        {
            //set spawn position to random place in front
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZTop);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

        }
        else 
        {
            //randomly pick left or right
            int leftOrRight = Random.Range(0, 2);
            if (leftOrRight == 0)
            {
                //set spawn position to random place on the right
                spawnPos = new Vector3(spawnRangeX, 0, Random.Range(spawnRangeZBottom, spawnRangeZTop));
                Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, -90, 0)));
            }
            else
            {
                //set spawn position to random place on the left
                spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(spawnRangeZBottom, spawnRangeZTop));
                Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(new Vector3(0, 90, 0)));
            }
            
        }
    

    }
}
