using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;
    private AudioSource backgroundMusic;
    public GameManager gameManager;
    public CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        backgroundMusic = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMusic.volume = volumeSlider.value;
        
        if (gameManager.gamePaused || !gameManager.isGameActive)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
        }
        else if (gameManager.isGameActive)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            
        }
    }
}
