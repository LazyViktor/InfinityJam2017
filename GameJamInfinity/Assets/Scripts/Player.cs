using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public float speed ;
    public int direction = 0;

    private Rigidbody2D rb;

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
	}

    void animationupdate()
    {









        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

    }

    void movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3 (-1*speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1*speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0,-1*speed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1*speed, 0);
        }
    }
}
