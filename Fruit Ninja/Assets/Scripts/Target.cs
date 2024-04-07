using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionPartical;
    

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torqueSpeed = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        targetRb.position = RandomPos();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //generate random force thrown up 
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    //generate random torque 
    float RandomTorque()
    {
        return Random.Range(-torqueSpeed, torqueSpeed);
    }
    //generate random position to spawn 
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    //destroy object when pressed on it
    private void OnMouseEnter()
    {
        if (gameManager.isGameActive && !gameManager.gamePaused && Input.GetMouseButton(0))
        {
            //if clicked on an bad object all good objects 
            if (gameObject.CompareTag("Bad"))
            {
                GameObject[] goodObjects = GameObject.FindGameObjectsWithTag("Good");
                if (goodObjects != null)
                {
                    for (int i = 0; i < goodObjects.Length; i++)
                    {
                        Vector3 force;
                        if (goodObjects[i].transform.position.x <= gameObject.transform.position.x)
                        {
                            force = Vector3.left;
                        }
                        else
                        {
                            force = Vector3.right;
                        }
                        goodObjects[i].gameObject.GetComponent<Rigidbody>().AddForce(force * 100, ForceMode.Impulse);

                    }
                    foreach (GameObject objects in goodObjects)
                    {
                        Destroy(objects);
                    }
                }


            }
            Destroy(gameObject);
            Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }

       
    
    //destroy obejcts out of screen and game over
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            gameManager.UpdateLives(1);
            if (gameManager.lives == 0)
            {
                gameManager.GameOver();
            }


        }
        
    }
}
