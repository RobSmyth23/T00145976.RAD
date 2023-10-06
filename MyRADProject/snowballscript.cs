using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowballscript : MonoBehaviour
{
    Rigidbody rb;
    internal int check = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void ImThrowingYou(Char_Control char_Control)
    {
        rb = GetComponent<Rigidbody>();
        transform.position = char_Control.transform.position + 2 * Vector3.up + 3 * char_Control.transform.forward;
        rb.velocity = 2 * (Vector3.up + 4 * char_Control.transform.forward);
    }
}