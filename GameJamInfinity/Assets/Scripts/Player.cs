using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public float speed;
    public int direction = 0;
    public Vector3 playerPosition;

    private Rigidbody2D rb;
    private Vector2 Velocity = new Vector2(0, 0);

    private Animator anim;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	



	// Update is called once per frame
	void Update () {
        movement();
        animationupdate();
        playerPosition = transform.position;
	}

    void animationupdate()
    {
        anim.SetFloat("XVelocity", Velocity.x);
        anim.SetFloat("YVelocity", Velocity.y);
       
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if(health < 1)
        {
            Debug.Log("Player dead!");
        }
    }

    void movement()
    {
        Velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            Velocity += new Vector2(-1, 0);
            //transform.position += new Vector3 (-1*speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Velocity += new Vector2(1, 0);
            //transform.position += new Vector3(1*speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Velocity += new Vector2(0, -1);
            //transform.position += new Vector3(0,-1*speed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Velocity += new Vector2(0, 1);
            //transform.position += new Vector3(0, 1*speed, 0);
        }

        transform.position += speed * new Vector3(Velocity.x,Velocity.y);
    }
}
