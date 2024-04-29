using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] GameObject hitEffectPrefab;
    //[SerializeField] GameObject startLine;
   // [SerializeField] GameObject finishLine;

    [HideInInspector] public float lapTimer = 0f;
    [HideInInspector] public int totalLaps = 0;
    public int maxLaps;

    public int collisionCount = 0;
    public int maxCollisionCount = 100000;

    //overall game timer
    public float maxGameTime = 15f;
    public float gameTime = 0f;

    //invincible period after collision timer variables
    private float invincibleTimer = 0f;
    private float invinciblePeriod = 0.2f;

    private GameObject playerObject;

    private void Start()
    {
        //find player gameobject
        playerObject = GameObject.Find("Player");
        //find game manager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //start game timer
        gameTime = 0f;

    }
    private void Update()
    {
        //start game timer -- 60 seconds to wreak havoc!!
        gameTime += Time.deltaTime;

        if (gameTime >= maxGameTime)
        {
            gameTime = maxGameTime;

            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            StartCoroutine(GameOverTimer());
            Destroy(playerObject);
        }


        //if invincible timer is greater than 0, count down
        if (invincibleTimer >= 0)
        {
            invincibleTimer -= Time.deltaTime;
        }


        //if car has completed less than max laps, hide finish line
        if (totalLaps < maxLaps)
        {
       //     finishLine.SetActive(false);
        }
        else
        {
            lapTimer = 0;
        }

        //if car has completed max laps, show finish line
        if (totalLaps == maxLaps)
        {
         //   finishLine.SetActive(true);
        }

        //if car has completed max laps, game over
        if (totalLaps > maxLaps)
        {
            totalLaps = maxLaps;
            gameManager.GameOver();
        }

        //if car has collided with max number of obstacles, game over
        if (collisionCount >= maxCollisionCount)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            StartCoroutine(GameOverTimer());
            Destroy(playerObject);
            //start game over timer
        }
    }

    //if car hits barrier, create hit effect
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collider name: " + collision.gameObject.name + " collider tag: " + collision.gameObject.tag);


        //for barriers don't destroy object, just create hit effect and add to collision count -- for obstacles, destroy object
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("Hit Barrier");
            Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
            //add to collision count
            //start collision timer for invincible period
            if (invincibleTimer <= 0)
            {
                invincibleTimer = invinciblePeriod;
               // collisionCount -= 1;
            }
        }
        //for obstacles, destroy object and create hit effect
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hit Obstacle");
            Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
            Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
            //add to collision count
            //start collision timer for invincible period
            if (invincibleTimer <= 0)
            {
                invincibleTimer = invinciblePeriod;
                collisionCount += 1;
            }
            //delete object collided with
            Destroy(collision.gameObject);
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

    //coroutine to count 2 seconds before game over state = true
    private IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(1.5f);
        gameManager.GameOver();
    }

}
