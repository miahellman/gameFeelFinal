using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }

    }
}
