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
    private void OnCollisionEnter(Collision collision)
    {
        print("You hit me!!!! Ouch!");
        DealWithHits thingIHit = collision.gameObject.GetComponent<DealWithHits>();
        if (thingIHit != null)
        {
            thingIHit.IHitYou();
        }
    }
    internal void ImThrowingYou(Char_Control char_Control)
    {
        transform.position = char_Control.transform.position + Vector3.up + 3 * char_Control.transform.forward;

        rb = GetComponent<Rigidbody>();
        rb.velocity = 2 * (Vector3.up + 4 * char_Control.transform.forward);
    }
}
