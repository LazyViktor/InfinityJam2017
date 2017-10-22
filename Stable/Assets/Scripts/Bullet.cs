using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage;
    public float speed;
    public Transform trans;
   

    private Vector2 Velocity = new Vector2(0, 0);
    private bool isFired = false;

    private Animator anim;
    private Rigidbody2D rb;

  

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        bulletMove();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        anim.SetFloat("XVelocity", Velocity.x);
        anim.SetFloat("YVelocity", Velocity.y);
    }

    void bulletMove()
    {

        Debug.Log(Velocity);
        Velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.LeftArrow) && !isFired )
        {
            Velocity += new Vector2(-1, 0);
            isFired = true;
            Debug.Log("is shooting");
            
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isFired)
        {
            Velocity += new Vector2(1, 0);
            isFired = true;
            Debug.Log("is shooting");
            
        }

        if (Input.GetKey(KeyCode.DownArrow) && !isFired)
        {
            Velocity += new Vector2(0, -1);
            isFired = true;
            Debug.Log("is shooting");
       
        }

        if (Input.GetKey(KeyCode.UpArrow) && !isFired)
        {
            Velocity += new Vector2(0, 1);
            isFired = true;
            Debug.Log("is shooting");
           
        }
        
        rb.velocity += Velocity*speed*0.9f;
    }

    
 
}

