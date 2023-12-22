using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Transform target;

    public Rigidbody2D rb;
    private Vector2 moveDirection;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        //Debug.Log("Im awake");
        rb = GetComponent<Rigidbody2D>();
        // Debug.Log("HELLO");
        player = GameObject.FindWithTag("Player");

        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //Debug.Log("im start");
        target = player.transform;
        //Debug.Log(target);
    }
    // Update is called once per frame
    void Update() {
        //  Debug.Log("hello");
       // Debug.Log(this.transform);

        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           // rb.rotation = angle;
            moveDirection = direction;
        }
    }
    void FixedUpdate()
    {
        if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
            
                if (moveDirection.x > 0)
                {
                    animator.SetFloat("Xinput", 1);
                animator.SetBool("isWalking", true);
                }
                else
                {
                    animator.SetFloat("Xinput", -1);
                }
            }
        //  Debug.Log(moveDirection.x);
        
    }

     
}

