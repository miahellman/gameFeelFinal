using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Scoreboard : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject managerObj;

    [Header("ui text fields")]
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text yourScoreText;


    void Awake()
    {
        managerObj = GameObject.Find("GameManager");
        gameManager = managerObj.GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        //update high score and your score text
        //help why is this not working
        highScoreText.text = $"fastest time: {PlayerPrefs.GetFloat("FastestTime", 0)} s";
        yourScoreText.text = $"your time: {gameManager.raceTime} s";

    }
}