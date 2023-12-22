using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyExplode : MonoBehaviour
{
    private GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("gameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GetComponent<gameManage>().enemiesRemaining = GameManager.GetComponent<gameManage>().enemiesRemaining - 1;
            Destroy(this.gameObject);
        }
    }
}
