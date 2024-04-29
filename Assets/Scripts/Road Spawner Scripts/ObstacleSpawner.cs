using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Position Data")]
    public GameObject maxX;
    public GameObject minX;
    public GameObject cam;

    [Header("Obstacles")]
    public GameObject obstacle1; 
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject spawn; 

    [Header("Timing Data")]
    [SerializeField] float timerMax;
    [SerializeField] float timerMin;
    [SerializeField] float timer; 

    private void Start()
    {
        cam = GameObject.Find("Camera");
        maxX = GameObject.Find("ObstacleSpawnerMax");
        minX = GameObject.Find("ObstacleSpawnerMin");
    }

    private void Update()
    {
        SetZPos();

        if (timer <= 0)
        {
            timer = 0;
            Spawning();
            //Timing(); 
        }

        if (timer > 0)
        {
            timer--;
        }
    }

    private void SetZPos()
    {
        float// positionZ = transform.position.z;
        positionZ = cam.transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, positionZ);
    }

    private void Timing()
    {

        //Spawning(); 
        //timer = (Random.Range(timerMin, timerMax));
    }

    private void Spawning()
    {
        #region random obstacle to spawn
        int spawnChoice = Random.Range(0, 3);

        if (spawnChoice == 0)
        {
            spawn = obstacle1;
        }
        if (spawnChoice == 1)
        {
            spawn = obstacle2;
        }
        if (spawnChoice == 2)
        {
            spawn = obstacle3;
        }
        if (spawnChoice == 3)
        {
            spawn = obstacle4;
        }
        #endregion

        float spawnPosX = Random.Range(minX.transform.position.x, maxX.transform.position.x); 

        Instantiate(spawn, new Vector3(spawnPosX, maxX.transform.position.y, maxX.transform.position.z), Quaternion.identity);

        timer = (Random.Range(timerMin, timerMax));

    }
}

