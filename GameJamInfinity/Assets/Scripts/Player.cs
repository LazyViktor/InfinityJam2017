using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public float speed;
    public int direction = 0;
    public GameObject Bullet;
    public int ammo;
    public int delay;
    private Rigidbody2D rb;
    private Vector2 Velocity = new Vector2(0, 0);
    private bool isWalking = false;

    private Animator anim;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	



	// Update is called once per frame
	void Update ()
    {
        movement();
        shoot();
        animationupdate();
        delay--;
	}

    void shoot()
    {
        if(ammo > 0 && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            if (delay <= 0)
            {
                GameObject newBullet = Instantiate(Bullet) as GameObject;
                newBullet.transform.position = transform.position;
                ammo--;
                delay = 20;

            }
           
        }

    }

    void animationupdate()
    {
        anim.SetFloat("XVelocity", Velocity.x);
        anim.SetFloat("YVelocity", Velocity.y);
       
    }

    void movement()
    {
        Debug.Log(Velocity);
        Velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            Velocity += new Vector2(-1, 0);
            isWalking = true;
            Debug.Log("is walking");
            //transform.position += new Vector3 (-1*speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Velocity += new Vector2(1, 0);
            isWalking = true;
            Debug.Log("is walking");
            //transform.position += new Vector3(1*speed, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            Velocity += new Vector2(0, -1);
            isWalking = true;
            Debug.Log("is walking");
            //transform.position += new Vector3(0,-1*speed, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Velocity += new Vector2(0, 1);
            isWalking = true;
            Debug.Log("is walking");
            //transform.position += new Vector3(0, 1*speed, 0);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            isWalking = false;
            Debug.Log("!walking");
        }

        transform.position += speed * new Vector3(Velocity.x,Velocity.y);
    }
}
