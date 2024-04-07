using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController playerControllerScript;
    private float leftboundary = -10;
    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    { 
        //get playercontroller script from the player 
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        player = playerControllerScript.gameObject;
        

    }

    // Update is called once per frame
    void Update()
    {

        if ((int)player.transform.position.x == 0)
        {
            playerControllerScript.playerAnim.SetBool("Static_b", true);
            playerControllerScript.playerAnim.SetFloat("Speed_f", 1);
            playerControllerScript.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            playerControllerScript.gameStart = true;
        }
        

        //speed up when c is pressed
        if (Input.GetKey(KeyCode.C) && playerControllerScript.gameStart)
        {
            speed = 40;
        }
        else
        {
            speed = 30;
        }
        // stop moving left if game is over
        if (!playerControllerScript.gameOver && playerControllerScript.gameStart)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //destroy obstacles out of bound
        if (transform.position.x < leftboundary && gameObject.CompareTag("Obstacle") && playerControllerScript.gameStart)
        {
            Destroy(gameObject);
        }

        
        
    }
}
