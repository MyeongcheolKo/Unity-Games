using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFood : MonoBehaviour
{
    public float spinSpeed = 50.0f;
    public float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spin the food
        transform.Rotate(0, spinSpeed, 0);
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
