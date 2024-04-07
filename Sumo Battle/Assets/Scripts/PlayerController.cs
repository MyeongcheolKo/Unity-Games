using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPowerup; 
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5;
    private float poerupStrength = 10;
    public GameObject powerupIndicater;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

        powerupIndicater.transform.position = transform.position;
        powerupIndicater.transform.Rotate(Vector3.up * speed);

    }

    //activate powerup when collide with a powerup 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicater.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdown());
        }

    }

    //use power up when collide with enemy and has powerup
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss") && hasPowerup)
        {
            
            enemyRb.AddForce(awayFromPlayer * poerupStrength, ForceMode.Impulse);
        }
        
    }
    //countdown for powerup 
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicater.gameObject.SetActive(false);
    }
}
