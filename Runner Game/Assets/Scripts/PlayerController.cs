using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashsound;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private bool highJump = false;
    private float score = 0;
    public bool gameStart = false;



    // Start is called before the first frame update
    void Start()
    {
        //get component and change the gravity
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        //jump when space pressed and the character is on the ground
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && gameStart)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            jumpParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1);
            highJump = true;
            Debug.Log("low");
        }
        else if (highJump && Input.GetKeyDown(KeyCode.Space) && !gameOver && gameStart)
        {
            playerRb.AddForce(Vector3.up * (jumpForce / 2), ForceMode.Impulse);
            jumpParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.8f);
            highJump = false;
            Debug.Log("high");
        }


        if (!gameOver && gameStart)
        {
            

            if (Input.GetKey(KeyCode.C))
            {
                score += Time.deltaTime * 20;
            }
            else
            {
                score += Time.deltaTime * 10;
            }
            Debug.Log((int)score);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //set player is on ground to true if player collides on ground
        if (collision.gameObject.CompareTag("Ground") && gameStart)
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        //game over if collides with an obstacle 
        else if (collision.gameObject.CompareTag("Obstacle") && gameStart)
        {
            Debug.Log("game over!");
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashsound, 1);
        }
    }
}
