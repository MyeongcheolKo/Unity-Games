using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundary = 30;
    private float lowBoundary = -5;
    private float sideBoundary = 24;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        //destroy object if out of lower, right or left bounds
        if (transform.position.z > topBoundary)
        {
            Destroy(gameObject);
        }
    }
}
