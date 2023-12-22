using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLifeTime : MonoBehaviour
{
    public Rigidbody2D rb;
    public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 300;
    }

    // Update is called once per frame
    void Update()
    {
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
}
