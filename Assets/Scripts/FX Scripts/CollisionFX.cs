using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject startLine;
    [SerializeField] GameObject finishLine;

    [HideInInspector] public float lapTimer = 0f;
    [HideInInspector] public int totalLaps = 0;
    public int maxLaps;

    private void Update()
    {
        //if car has completed less than max laps, hide finish line
        if (totalLaps < maxLaps)
        {
            finishLine.SetActive(false);
        }
        else
        {
            lapTimer = 0;
        }

        //if car has completed max laps, show finish line
        if (totalLaps == maxLaps)
        {
            finishLine.SetActive(true);
        }

        //if car has completed max laps, game over
        if (totalLaps > maxLaps)
        {
            totalLaps = maxLaps;
            gameManager.GameOver();
        }
    }

    //if car hits barrier, create hit effect
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
        }
    }

    //if car hits start line, add to total laps
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("StartLine"))
        {
            Debug.Log("Start Line");
            totalLaps += 1;
        }

    }

}
