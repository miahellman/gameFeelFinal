using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] GameObject roadSection;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            //intantiate road section so it adds on to current track
            Instantiate(roadSection, new Vector3(0, -0.61f, player.transform.position.z + 78f), Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
