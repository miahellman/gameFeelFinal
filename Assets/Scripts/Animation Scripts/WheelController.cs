using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [Header("wheels")]
    public GameObject[] wheelsToRotate;

    [Header("effects")]
    public TrailRenderer[] trails;

    [Header("movement")]
    public CarController carController;
    public float rotationSpeed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get input from player
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        //for each wheel in the array, rotate the wheel
        foreach (var wheel in wheelsToRotate)
        {
            wheel.transform.Rotate(0, 0, Time.deltaTime * verticalAxis * rotationSpeed, Space.Self);
        }

        //set animation for turning
        #region wheel turning animation
        if (horizontalAxis > 0)
        {
            //turning right
            anim.SetBool("goingLeft", false);
            anim.SetBool("goingRight", true);
        }
        else if (horizontalAxis < 0)
        {
            //turning left
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", true);
        }
        else
        {
            //must be going straight
            anim.SetBool("goingRight", false);
            anim.SetBool("goingLeft", false);
        }
        #endregion

        //emit trails if car is moving l or r - or if car is moving slow
        if (horizontalAxis != 0 || carController.carSpeed < 10f)
        {
            foreach (var trail in trails)
            {
                trail.emitting = true;
            }

        }
        else
        {
            foreach (var trail in trails)
            {
                trail.emitting = false;
            }

        }
    }
}