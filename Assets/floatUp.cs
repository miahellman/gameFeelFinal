using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatUp : MonoBehaviour
{
    float timer = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer *= Time.deltaTime;
        timer--; 

        if (timer < 0)
        {
            Destroy(gameObject);
        }

        float up;
        float front; 
        up = transform.position.y;
        front = transform.position.x + 50; 

        up += .1f; 

        transform.position = new Vector3 (front, up, transform.position.z);
    }
}
