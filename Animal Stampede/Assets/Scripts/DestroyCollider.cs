using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCollider : MonoBehaviour
{
    //public Slider slider;
    //private int foodNeeded = 3;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject sliderObj = new GameObject("HungerBar");
        //slider.maxValue = foodNeeded;
        //slider.value = 0;
        //Instantiate(sliderObj, transform.position, slider.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //slider.transform.position = transform.position + Vector3.up;
        //if (slider.value == foodNeeded)
        //{
        //    Debug.Log("uuu");
        //    Destroy(gameObject);
        //}
    }

    //destroy the objects when collide 
    private void OnTriggerEnter(Collider other)
    {
        //slider.value++;
        Destroy(gameObject);
    }
}
