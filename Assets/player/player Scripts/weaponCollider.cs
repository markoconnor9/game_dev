// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

// Library Imports are used to access many of Unity's
// built in C# functions to make game programming easy.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class weaponCollider : MonoBehaviour
{
    // The time that the object stays in the scene.
    public float lifetime;
    public float damage;
    public float hitCount;
    public float numberOfHitsAllowed;
    public float cooldown;
    // assign the Game Manager
    public GameObject gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        // If the life timer has hit zero...
        if (lifetime <= 0)
        {
            // Destroy this object
           // gameManager.GetComponent<UpdatedGameManager>().score += 1000;
            Destroy(this.gameObject);
        }
        // If not...
        else
        {
            // Decrement the timer
            lifetime = lifetime - (20f * Time.deltaTime);
            //lifetime--;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the projectile has hit an enemy...
        if (other.tag == "enemy")
        {
            
           GameObject enemy = other.gameObject;
            float enemyHealth = enemy.GetComponent<enemyStats>().health;
            enemyHealth = enemyHealth - damage;
            if (enemyHealth <= 0)
            {
                Transform enemyLocation = enemy.transform;
                Destroy(other.gameObject);
                this.GetComponent<dropItem>().item(enemyLocation);
                gameManager.GetComponent<gameManage>().enemiesRemaining = gameManager.GetComponent<gameManage>().enemiesRemaining - 1;
            }
            else
            {
                enemy.GetComponent<enemyStats>().health = enemyHealth; 
            }

            // Destroy the enemy
            //  gameManager.GetComponent<UpdatedGameManager>().score += 50;

            // Destroy the projectile by setting
            // the timer to 0.
            hitCount++;
            
            if(hitCount == numberOfHitsAllowed) 
            {
                lifetime = 0;
            }
            // Add score on destruction
            //gameManager.GetComponent<GameManager>().score += 1000;
        }
    }
}
