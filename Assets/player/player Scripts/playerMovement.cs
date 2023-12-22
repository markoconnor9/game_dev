// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Every Unity script derives from the MonoBehaviour class
// where your script class is the script name you set before.
public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    bool touchingWeapon;
    private Rigidbody2D newWeapon;
    private GameObject pickup;
    //How long it takes for a enemy to damage the player a second time
    public float waitTime;
    // We use Update to call GetButtonUp for our Force Offset.
    //public GameObject sceneManager;
    private Animator animator;

    void Start()
    {
        //   Debug.Log("player start");
        touchingWeapon = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log("message");

        ProcessInput();
        
        if(touchingWeapon == true)
        {
            if (Input.GetKeyDown("q"))
            {
                Debug.Log("pick up");
                this.GetComponent<shoot>().primaryWeapon = newWeapon;
                this.GetComponent<shoot>().rangeAttack = this.GetComponent<shoot>().primaryWeapon.GetComponent<isRanged>().rangedWeapon;
                this.GetComponent<shoot>().primaryCoolDown = this.GetComponent<shoot>().primaryWeapon.GetComponent<weaponCollider>().cooldown;
                Destroy(pickup);


            }
            else if (Input.GetKeyDown("e"))
            {
                this.GetComponent<shoot>().secondaryWeapon = newWeapon;
                this.GetComponent<shoot>().rangeSecondary = this.GetComponent<shoot>().secondaryWeapon.GetComponent<isRanged>().rangedWeapon;
                this.GetComponent<shoot>().secondaryCoolDown = this.GetComponent<shoot>().secondaryWeapon.GetComponent<weaponCollider>().cooldown;
                Destroy(pickup);

            }
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    private String lastDirection;
    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
     //   Debug.Log(moveX);
        if (moveX == 0 && moveY == 0)
        {
            animator.SetTrigger("idle");
        }
        else if(moveX == -1) {
            animator.SetTrigger("runLeft");
            lastDirection = "left";
        }
        else if (moveX == 1)
        {
            animator.SetTrigger("runRight");
            lastDirection = "right";
        }
        else if(moveX == 0 && moveY!=0) {
            if(lastDirection == "left")
            {
                animator.SetTrigger("runLeft");
            }
            else
            {
                animator.SetTrigger("runRight");
            }
        }
        
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Debug.Log(collision.gameObject.tag);
            float temp = this.GetComponent<playerStats>().health;
            float damageTaken = collision.gameObject.GetComponent<enemyStats>().damage;
            this.GetComponent<playerStats>().health = temp - damageTaken;
            temp = temp - damageTaken;
        //    Debug.Log(temp);
            if (temp <= 0)
            {
                //Debug.Log("game over");
                //    Destroy(this.gameObject);
                this.GetComponent<endGame>().endingGame();
                //sceneManager.GetComponent<SceneManagerScript>().quitGame();


            }

        }
        else if (collision.gameObject.tag == "percent health buff")
        {
            float maxHealth = this.GetComponent<playerStats>().currentMaxHealth;
            float currentHealth = this.GetComponent<playerStats>().health;
            float addedHealth = maxHealth * 0.2f;
            if(currentHealth + addedHealth > maxHealth)
            {
                this.GetComponent<playerStats>().health = maxHealth;
            }
            else
            {
                this.GetComponent<playerStats>().health = currentHealth + addedHealth;
            }

            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.tag == "max health buff")
        {
            float maxHealth = this.GetComponent<playerStats>().currentMaxHealth;
            maxHealth = maxHealth + 50;
           if(maxHealth > 500)
            {
                maxHealth = 500;
            }
            
            this.GetComponent<playerStats>().currentMaxHealth = maxHealth;
            this.GetComponent<playerStats>().health = maxHealth;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "movement speed buff")
        {
            moveSpeed++;
            if(moveSpeed > 15)
            {
                moveSpeed = 15;
            }
            Destroy(collision.gameObject);
        }
       





    }
    void OnCollisionStay2D(Collision2D collision)
    {
     //   Debug.Log(collision.gameObject.ToString());
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemyMovement>().rb.velocity = new Vector2(0,0);
            if (waitTime == 100)
            {
                float temp = this.GetComponent<playerStats>().health;
                float damageTaken = collision.gameObject.GetComponent<enemyStats>().damage;
                this.GetComponent<playerStats>().health = temp - damageTaken;
                waitTime = 0;

                temp = temp - damageTaken;
                
                if (temp <= 0)
                {

                    //Debug.Log("game over");
                    //  Destroy(this.gameObject);
                    this.GetComponent<endGame>().endingGame();
                  //  sceneManager.GetComponent<SceneManagerScript>().quitGame();
                }
            }
            else
            {
                waitTime++;
            }
        }

        //all weapon pick ups just use spear pickup tag lol
        else if (collision.gameObject.tag == "spear pickup")
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("pick up");
            }
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        //all weapon pick ups just use spear pickup tag lol

        if (other.gameObject.tag == "spear pickup")
        {
            touchingWeapon = true;
            pickup = other.gameObject;
            newWeapon = other.GetComponent<weaponAttached>().rb;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "spear pickup")
        {
            pickup = null;
            touchingWeapon = false;
        }
    }
}