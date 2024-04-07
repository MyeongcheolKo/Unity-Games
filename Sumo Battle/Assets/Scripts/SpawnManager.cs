using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public GameObject bossPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNum = 1;
    public bool bossRound = false;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.gameObject.transform.rotation);
        spawnEnemyWave(waveNum);
    }

    // Update is called once per frame
    void Update()
    {
    
        //respawn enemies and powerups when enemies are all dead
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNum++;
            spawnEnemyWave(waveNum);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.gameObject.transform.rotation);
        }

    }
    //spawn number of enemies accordingly as game proccess
    void spawnEnemyWave(int enemiesToSpawn)
    {
        bossRound = waveNum % 3 == 0;
        Debug.Log(bossRound);
        if (bossRound)
        {
            Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        }
        else
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
        
    }

    //generate random spawn position
    private Vector3 GenerateSpawnPosition()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
