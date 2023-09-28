using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Control : MonoBehaviour
{
    private float currentSpeed;
    private float walkingSpeed = 2;
    private float runningSpeed = 4;
    private float turningSpeed = 180;
    Animator myAnimator;

    
    void Start()
    {
        currentSpeed = walkingSpeed;
        runningSpeed = walkingSpeed * 3;
        myAnimator = GetComponent<Animator>();


    }

    void Update()
    {
        myAnimator.SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.W))
        {
            myAnimator.SetBool("IsWalking", true);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetBool("IsRunning", true);
            transform.position += runningSpeed * transform.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            myAnimator.SetBool("IsWalking", true);

            transform.position -= currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.down, turningSpeed * Time.deltaTime);
        }
       
        
    }
}