using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{
    public GameObject[] lives;
    static int liveCountdown = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int livesLength = lives.Length;
        Destroy(lives[livesLength - 1 - liveCountdown]);
        Debug.Log(liveCountdown);
        Destroy(other.gameObject);
        if (liveCountdown == 2)
        {
            Debug.Log("Game Over!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        liveCountdown += 1;
        
    }


}
