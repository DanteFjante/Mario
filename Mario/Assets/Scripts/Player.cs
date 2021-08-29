using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    public int Lives;


    
    public void Kill()
    {
        if(Lives == 0)
            gameObject.SetActive(false);
    }
    
    public void Damage()
    {
        Lives--;


    }
    
    public void Jump()
    {
        
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
