using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerControl : MonoBehaviour
{
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        //Debug.Log(time);
        if(time > 0.5f)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
        }
    }
}
