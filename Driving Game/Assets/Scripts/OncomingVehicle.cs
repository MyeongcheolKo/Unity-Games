using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OncomingVehicle : MonoBehaviour
{
    
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the vehicals
        transform.Translate(Vector3.forward * Time.deltaTime * -speed);
    }
}
