using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed = 5;
    private bool bossRound;
    private float bossBoundary = 9;
    
    private bool bossPower = true;
    private int bossBattleTime = 10;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        bossRound = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().bossRound;
    }

    // Update is called once per frame
    void Update()
    {
        //move the enemies towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (bossRound)
        {
            StartCoroutine(bossPowerCountdown());
            if (bossPower && (transform.position.x > bossBoundary || transform.position.x < -bossBoundary || transform.position.z > bossBoundary || transform.position.z < -bossBoundary))
            {
                //Debug.Log("Boss Round");
                enemyRb.AddForce(lookDirection * speed, ForceMode.Impulse);
                
            }
        }
        
        
        //destroy the enemies if drop down the cliff
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator bossPowerCountdown()
    {
        yield return new WaitForSeconds(bossBattleTime);
        Debug.Log("boss battle over");
        bossPower = false;
        bossBattleTime += 5;
    }
}
