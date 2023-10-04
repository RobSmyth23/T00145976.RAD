using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Char_Control : MonoBehaviour
{
    float currentSpeed;
    float walkingSpeed = 2;
    float runningSpeed = 4;
    private float turningSpeed = 180;
    Animator myAnimator;
    Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float jumpforce = 1f;
    public GameObject snowballCloneTemplate;


    void Start()
    {
        currentSpeed = walkingSpeed;
        runningSpeed = walkingSpeed * 3;
        myAnimator = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();

        

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
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
            myAnimator.SetBool("IsJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
           GameObject newGo = Instantiate(snowballCloneTemplate);
            
           snowballscript mySnowBall = newGo.GetComponent<snowballscript>();

            mySnowBall.ImThrowingYou(this);
        }
        
        }
    
           
    }