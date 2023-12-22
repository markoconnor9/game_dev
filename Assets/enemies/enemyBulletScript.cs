using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);


    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0)
        {
           // Debug.Log("lifeTime");
            // Destroy this object
            // gameManager.GetComponent<UpdatedGameManager>().score += 1000;
            Destroy(this.gameObject);
        }
        // If not...
        else
        {
            // Decrement the timer
            lifetime--;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
   
        // Debug.Log("hit");
        // If the projectile has hit an enemy...
        if (other.gameObject.tag == "Player")
        {
          //  Debug.Log("hit a player");
            Destroy(this.gameObject);
        }
        else
        {

        }
    }
  
}