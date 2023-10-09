using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithHits : MonoBehaviour
{
    int Health = 500;
    internal void IHitYou()
    {
        Health -= 20;

        if (Health < 50)
        {
            GetComponentInChildren<Renderer>().material.color = Color.magenta;
        }
        if (Health < 0)
        { 
            Destroy(gameObject);
        }
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
