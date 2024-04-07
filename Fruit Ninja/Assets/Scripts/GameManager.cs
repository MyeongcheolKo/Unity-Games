using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI pausedText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject playerTrail;
    private TrailRenderer trailRenderer;

    private float spawnRate = 2;
    private int score;
    public int lives = 3;

    public bool isGameActive;
    public bool gamePaused = false;
    // Start the game, set the difficulty,
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;


        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        UpdateLives(0);
        trailRenderer = playerTrail.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //pause the game when space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGameActive)
        {
            if(!gamePaused)
            {
                Time.timeScale = 0;
                GameObject.Find("Volume Slider").gameObject.GetComponent<AudioSource>().Pause();
                gamePaused = true;
                pausedText.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                GameObject.Find("Volume Slider").gameObject.GetComponent<AudioSource>().UnPause();
                gamePaused = false;
                pausedText.gameObject.SetActive(false);
            }
            
        }

        //trail follows the player
        if (Input.GetMouseButton(0) && isGameActive && !gamePaused)
        {
            trailRenderer.enabled = true;
            Vector3 curserPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curserPos.z = 2;
            playerTrail.transform.position = curserPos;
        }
        else if (isGameActive)
        {
            trailRenderer.enabled = false;
            trailRenderer.Clear();
        }

        

    }
    //spawn target every setted interval as game is started
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }
    //uptate the score for the ui test 
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    //display game over when game ends
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    //reload the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //update the lives of the player
    public void UpdateLives(int livesToLoose)
    {
        if (isGameActive)
        {
            lives -= livesToLoose;
            livesText.text = "Lives: " + lives;
        }
        
    }
}
