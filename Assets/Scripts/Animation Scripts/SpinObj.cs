using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObj : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, Time.deltaTime * 20, 0, Space.Self);
    }
}
