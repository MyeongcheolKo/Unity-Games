using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerP1 : MonoBehaviour
{
    // variables
    [SerializeField] float speed = 15.0f;
    private float turnSpeed = 80.0f;
    private float horizontalInput;
    private float forwardInput;
    public Camera mainCamera;
    public Camera secondCamera;
    private Vector3 offsetMain = new Vector3(0, 5, -7);
    private Vector3 offsetSecond = new Vector3(0, 2, 2.5f);
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        secondCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //get user horizontal and forward input 
        horizontalInput = Input.GetAxis("HorizontalWASD");
        forwardInput = Input.GetAxis("VerticalWASD");

        //Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //Rotate the vehicle based on horizaontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        //Move main and second camera follow the vehical
        mainCamera.transform.position = transform.position + offsetMain;
        secondCamera.transform.position = transform.position + offsetSecond;
        if (secondCamera.enabled)
        {
            secondCamera.transform.rotation = transform.rotation;
        }

        //enable main or second camera from user input
        if (Input.GetKeyDown(KeyCode.F))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }

    }
}
