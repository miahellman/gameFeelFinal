using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CollisionFX collisionFX;
    public bool gamePaused = false;
    public ModifyUI modifyUI;
    public float raceTime;

    private float gameTimer = 0f;

    //singleton 
    public static GameManager instance;

    [HideInInspector] public bool isGameOver = false;

    //singleton pattern
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //find modifyUI component in canvas
        modifyUI = GameObject.Find("Canvas").GetComponent<ModifyUI>();
        collisionFX = GameObject.Find("CarCollider").GetComponent<CollisionFX>();
    }
    // Update is called once per frame
    void Update()
    {
        //pausing game function
        //pause game function for gameplay scene only
        if (Input.GetKeyUp(KeyCode.Escape) && gamePaused == false) { gamePaused = true; }
        else if (Input.GetKeyUp(KeyCode.Escape) && gamePaused == true) { gamePaused = false; }

        Time.timeScale = gamePaused ? 0 : 1;

        //check fastest time
        CheckFastestTime();
    }

    //start game function
    public void StartGame()
    {
        SceneManager.LoadScene("infinite demo");

        //start game timer
        gameTimer += Time.deltaTime;

    }

    //game over function
    public void GameOver()
    {
        isGameOver = true;

        if (isGameOver)
        {
            SceneManager.LoadScene("End");
        }

    }

    //reset game function
    public void ResetGame()
    {
        SceneManager.LoadScene("Start");
    }

    //quit game function
    public void QuitGame()
    {
        Application.Quit();
    }

    //check fastest time for scoreboard (this is broken)
    private void CheckFastestTime()
    {
       //save high and low scores
        raceTime = collisionFX.collisionCount;

        if (PlayerPrefs.GetFloat("LongestTime",0) == 0)
        {
            PlayerPrefs.SetFloat("LongestTime", raceTime);
        } 
        else if (raceTime >= PlayerPrefs.GetFloat("LongestTime", 0))
        {
            PlayerPrefs.SetFloat("LongestTime", raceTime);
        }

        if (PlayerPrefs.GetFloat("CurrentTime", 0) == 0)
        {
            PlayerPrefs.SetFloat("CurrentTime", raceTime);
        }
        else if (raceTime <= PlayerPrefs.GetFloat("LongestTime", 0))
        {
            PlayerPrefs.SetFloat("CurrentTime", raceTime);
        }
    }
}
