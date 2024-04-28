using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentBarriers : MonoBehaviour
{
    private void Awake()
    {
        //find all objects with the tag "Barrier"
        GameObject[] barriers = GameObject.FindGameObjectsWithTag("Barrier");
        //set the parent of each object to null
        foreach (GameObject barrier in barriers)
        {
            barrier.transform.parent = null;
        }
    }

}
