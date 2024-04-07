using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSpinner : MonoBehaviour
{
    private float rotSpeed = 30;
    private bool isSpinning = false;
    private bool mouseOnHold = false;
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //reset the wheel when it stop spinning
        if ((int)rotSpeed == 0)
        {
            isSpinning = false;
            rotSpeed = 30;
            
        }

        //play particle effects when mouse down
        if(Input.GetMouseButtonDown(0) && !isSpinning)
        {
            mouseOnHold = true;
            particles.Play();
        }
        //stop particle effects and spin the wheel when mouse up
        if (Input.GetMouseButtonUp(0) && !isSpinning)
        {
            particles.Stop();
            isSpinning = true;
            mouseOnHold = false;
        }
        //increase the speed when mouse is not realeased
        if (mouseOnHold)
        {
            rotSpeed *= 1.05f;
        }
        //rotate the wheel
        if (isSpinning)
        {
            gameObject.transform.Rotate(0, 0, rotSpeed);
            rotSpeed *= 0.96f;
        }
        
        
    }
}
