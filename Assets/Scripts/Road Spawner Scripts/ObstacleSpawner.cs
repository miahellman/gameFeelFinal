using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private int spawnInterval = 10;
    private int lastSpawnZ = 16;
    private int SpawnAmount = 4;

    public List<GameObject> obstacles;

    //spawn obstacles on awake
    private void Awake()
    {
        SpawnObstacles();
    }

    public void SpawnObstacles()
    {
        //spawn obstacles at intervals
        lastSpawnZ += spawnInterval;

        //spawn obstacles at random intervals
        for (int i = 0; i < SpawnAmount; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                GameObject obstacle = obstacles[Random.Range(0, obstacles.Count)];

                Instantiate(obstacle, new Vector3(0, 0.25f, lastSpawnZ), obstacle.transform.rotation);
            }
        }
    }
}

