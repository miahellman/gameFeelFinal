using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickSceneNav : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //find gamemanager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if hit 'A' on xbox controller
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("A button pressed");

            //if hit a on xbox controller start game
            if (SceneManager.GetActiveScene().name == "Start")
            {
                gameManager.StartGame();
            }
            //if hit a on xbox controller restart game
            if (SceneManager.GetActiveScene().name == "End")
            {
                gameManager.ResetGame();
            }
        }
    }
}
