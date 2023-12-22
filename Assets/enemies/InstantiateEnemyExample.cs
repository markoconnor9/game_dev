// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemyExample : MonoBehaviour
{
    // The rate at which our enemies spawn.
    public float rate;
    float setrate;

    // The variable that speeds up enemy spawn rate.
    public float diff;

    // Our enemy prefab object
    public GameObject enemy;

    // The two points that spawning will occur between.
    public Transform min;
    public Transform max;


    void Awake()
    {
        // Set the setrate to the initial rate.
        setrate = rate;
    }

    void Update()
    {
        //  If the rate  timer has not hit 0...
        if (rate <= 0)
        {
            // Determine where the enemy will spawn.

            // Get the difference between the positions.
            Vector3 difference = min.position - max.position;

            // Generate a random position between those positions. 
            // If random is 0, then position is min. If 1, then max.
            Vector3 new_difference = difference * Random.Range(0.0f, 1.0f);

            // Store it in a new variable by subtracting
            // the new difference by the first position.
            Vector3 randomPos = min.position - new_difference;

            // Instantiate the enemy prefab
            GameObject clone = Instantiate(enemy, randomPos, Quaternion.identity);

            // Decrease the rate so enemies spawn faster
            rate = setrate - diff;

            // Do not let the difficulty rise too high.
            // If so, enemies will spawn faster than we
            // will be able to realistically handle.
            if (diff >= setrate / 2)
            {
                diff = setrate / 2;
            }
            // If not too difficult, increment difficulty.
            else
            {
                diff += diff;
            }        
        }
        // Decrement rate timer.
        else
        {
            rate--;
        }
    }
}
