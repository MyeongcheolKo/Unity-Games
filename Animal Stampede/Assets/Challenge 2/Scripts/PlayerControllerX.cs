using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnInterval = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        spawnInterval += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && spawnInterval >= 2.0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spawnInterval = 0;
        }
    }
}
