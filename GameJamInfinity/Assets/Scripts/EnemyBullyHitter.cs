﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullyHitter : MonoBehaviour {

    public int health;
    public float speed;
    public int direction = 0;

    //chasing stuff
    public Player target;

    // Meele Attack Stuff
    public int meeleDamage;
    public float meeleAttackCooldown;
    private float lastAttackTime;
    public float attackRange;
    
    private Rigidbody2D rb;
    private Vector2 Velocity = new Vector2(0, 0);

    //private Animator anim;

    // Use this for initialization
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
     //   anim = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        MeeleAttack();
     //   animationupdate();
    }

    //void animationupdate()
    //{
    //    anim.SetFloat("XVelocity", Velocity.x);
    //    anim.SetFloat("YVelocity", Velocity.y);

    //}

    // Use ???.SendMessage("TakeDamage", int number); to deal damage to enemy.
    void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 1)
        {
            Debug.Log("Enemy dead!");
        }
    }

    void MeeleAttack()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.playerPosition);
        // AttackRange Test
        if(distanceToTarget < attackRange)
        {   
            // CoolDown Test
            if(lastAttackTime + meeleAttackCooldown < Time.time)
            {
                lastAttackTime = Time.time;
                target.SendMessage("TakeDamage", meeleDamage);
                Debug.Log("Attack");
            }
        }
    }

    Vector3 Chase()
    {
        Vector3 targetDir = target.playerPosition - transform.position;

        return targetDir;
    }

    void Movement()
    {
        Velocity = new Vector2(0, 0);

        transform.position += speed * Chase();
    }
}
