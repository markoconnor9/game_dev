using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPos;
    public float distanceToShoot;
    public float timer;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceToShoot)
        {
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }

       
        {
            
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

}
