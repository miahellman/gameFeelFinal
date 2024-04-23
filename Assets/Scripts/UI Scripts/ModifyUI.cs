using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyUI : MonoBehaviour
{
    public GameManager gameManager;
    public CarController carController;
    public CollisionFX collisionFX;

    [SerializeField] TextMeshProUGUI mphText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI lapsText;
    [SerializeField] TextMeshProUGUI pauseText;

    public float timeElapsed = 0f;
    private float speed = 0f;
    

    // Update is called once per frame
    void Update()
    {
        // If car speed is positive add to speed until reaching car speed, if car speed is negative, subtract until reaching car speed
        if (speed < carController.carSpeed)
        {
            speed += 0.5f;
        }
        else if (speed > carController.carSpeed)
        {
            speed -= 1f;
        }
        else
        {
            speed = carController.carSpeed; // If car speed is 0, set speed to 0
        }

        //update text to show game is paused if paused is true
        pauseText.text = gameManager.gamePaused ? "PAUSED" : "";

        //update text if paused don't show text, else show text
        mphText.text = gameManager.gamePaused ? "" : speed.ToString("F0") + " MPH";

        timeElapsed += Time.deltaTime;

        timeText.text = gameManager.gamePaused ? "" : "TOTAL TIME: " + timeElapsed.ToString("F0") + " S";

        lapsText.text = gameManager.gamePaused ? "" : "LAPS: " + collisionFX.totalLaps.ToString("F0") + "/" + collisionFX.maxLaps.ToString();
        
    }
}
