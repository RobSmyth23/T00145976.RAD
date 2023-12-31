using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class Char_Control : MonoBehaviour
{
    float currentSpeed;
    float walkingSpeed = 3;
    float runningSpeed = 4;
    private float turningSpeed = 120;
    Animator myAnimator;
    Rigidbody rb;
    BoxCollider bc;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float jumpforce = 0.10f;
    public GameObject snowballCloneTemplate;
    bool IsJumpingUp, IsFalling;


    void Start()
    {
        currentSpeed = walkingSpeed;
        runningSpeed = (float)(walkingSpeed * 2.5);
        myAnimator = GetComponent<Animator>();
        
        rb = GetComponent<Rigidbody>();
        

    }

    void Update()
    {
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetBool("IsRunning", false);
        myAnimator.SetBool("IsJumping", false);
        if (IsJumpingUp && (rb.velocity.y <= 0)) IsFalling = true;
        if (IsFalling && (rb.velocity.y >= 0))
        {
            myAnimator.SetBool("IsJumping", false);
            IsFalling = false;
            IsJumpingUp = false;
        }

        if (Input.GetKey(KeyCode.W))
        {
            myAnimator.SetBool("IsWalking", true);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            myAnimator.SetBool("IsRunning", true);
            transform.position += currentSpeed * transform.forward * Time.deltaTime;
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
            myAnimator.SetBool("IsJumping", true);
            IsJumpingUp = true;
            rb.AddExplosionForce(1100, transform.position + Vector3.down, 5);
           
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           GameObject newGo = Instantiate(snowballCloneTemplate);
            
           snowballscript mySnowBall = newGo.GetComponent<snowballscript>();

            mySnowBall.ImThrowingYou(this);
        }
        
        }
    
           
    }