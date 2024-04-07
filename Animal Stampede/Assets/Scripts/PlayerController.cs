using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed = 50;
    public GameObject food;
    public float topBoundary = 15;
    public float bottomBoundary = -2;
    public float sideBoundary = 24;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move player according to input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //spawn food if space pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position + Vector3.up, food.transform.rotation);
        }

        //prevant player going out of bound
        if (transform.position.z > topBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBoundary);
        }
        if (transform.position.z < bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBoundary);
        }
        if (transform.position.x < -sideBoundary)
        {
            transform.position = new Vector3(-sideBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > sideBoundary)
        {
            transform.position = new Vector3(sideBoundary, transform.position.y, transform.position.z);
        }
    }
}
