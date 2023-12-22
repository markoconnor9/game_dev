// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

// Library Imports are used to access many of Unity's
// built in C# functions to make game programming easy.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.EventSystems.EventTrigger;

// Every Unity script derives from the MonoBehaviour class
// where your script class is the script name you set before.
public class gameManage : MonoBehaviour
{
    /* Declaring any object as public will make it available 
       to be accessed by other scripts. Furthermore, variables
       that have been declared public can be seen and edited within
       the Unity Inspector for faster gameplay testing */

    // When an object does not state its publicity, it is assumed private.

    // Variable declarations go here.
    // the current game score.
    public int score;

    // the GameObject that acts as our player object
    // will be the Square sprite we created. The GameObject
    // type represents any entity within the Unity scene.
    public GameObject player;

    //level controls
    public int level;
    private float numberOfEnemies;
    private float numberOfBasic;
    private float numberOfFast;
    private float numberOfExplode;
    private float numberOfShooting;
    public float enemiesRemaining;

    //Time between rounds
    public float timeBetweenRounds;
    public float timeBetweenRoundsRemaining;

    //Spawning variables

    public float rate;
    float setrate;

    // The variable that speeds up enemy spawn rate.
    public float spawnRate;

    // Our enemy prefab object
    public GameObject basicEn;
    public GameObject fastEn;
    public GameObject explodeEn;
    public GameObject shootingEn;
    public GameObject[] listOfEnemies;

    // The two points that spawning will occur between.
    public Transform topLeft;
    public Transform topMiddle;
    public Transform topRight;
    public Transform leftTop;
    public Transform leftBottom;
    public Transform rightTop;
    public Transform rightBottom;

    public GameObject sceneManager;

    private Vector3 spawnAt;
    // Initialization of variables go here.

    private bool forceValue;
    void Awake()
    {
        if (PlayerPrefs.GetInt("h_score") > 0)
        {
            score = PlayerPrefs.GetInt("h_score");
        }
        level = 0;
        setrate = rate;
        timeBetweenRoundsRemaining = timeBetweenRounds;
        listOfEnemies = new GameObject[] { basicEn, fastEn, explodeEn, shootingEn };
        forceValue = false;
    }

    // Update is called once per frame. Imagine a while  
    // loop that runs until the game is stopped.
    void Update()
    {
        if (enemiesRemaining < 0)
        {
            numberOfEnemies = 0;
            level++;
        }
        levelControl();
        enemySpawning();




        /*

        // if the player object still exists
        // within the scene...
        if (player)
        {
            if (TimeManagement.currentTime <= 0)
            {
                score++;
            }
        }
        else
        {
            // otherwise, go back to main menu
            SceneManagerExample.instance.LoadMainMenu();
        }
    */
    }

    void levelControl()
    {
        if (enemiesRemaining == 0)
        {
            if (timeBetweenRoundsRemaining <= 0)
            {
                level++;
                nextLevel();

            }
            else
            {
                timeBetweenRoundsRemaining -= Time.deltaTime;
                if (enemiesRemaining < 0)
                {
                    numberOfEnemies = 0;
                    level++;
                }
            }
        }
    }
    void nextLevel()
    {
        if (level == 1)
        {
          //  sceneManager.GetComponent<SceneManagerScript>().playerWon();

            
            numberOfBasic = 10;
            numberOfEnemies = 10;
            enemiesRemaining = numberOfEnemies;
            numberOfFast = 0;
            numberOfExplode = 0;
            numberOfShooting = 0;
           
            spawnRate = 250;
        
        }
        else if (level == 2)
        {
            
                numberOfBasic = 15;
                numberOfEnemies = 20;
                enemiesRemaining = numberOfEnemies;
                numberOfFast = 0;
                numberOfExplode = 0;
                numberOfShooting = 5;

                spawnRate = 250;
           
            //sceneManager.GetComponent<SceneManagerScript>().playerWon();
        }
        else if (level == 3)
        {
            numberOfBasic = 0;
            numberOfEnemies = 50;
            enemiesRemaining = numberOfEnemies;
            numberOfFast = 50;
            numberOfExplode = 0;
            numberOfShooting = 0;

            spawnRate = 300;

        }
        else if (level == 4)
        {

            numberOfBasic = 60;
            numberOfEnemies = 100;
            enemiesRemaining = numberOfEnemies;
            numberOfFast = 15;
            numberOfExplode = 5;
            numberOfShooting = 20;

            spawnRate = 350;

        }
        else if (level == 5)
        {
            numberOfBasic = 100;
            numberOfEnemies = 200;
            enemiesRemaining = numberOfEnemies;
            numberOfFast = 50;
            numberOfExplode = 10;
            numberOfShooting = 40;

            spawnRate = 400;


        }
        else if (level == 6)
        {
            sceneManager.GetComponent<SceneManagerScript>().playerWon();
        }


        timeBetweenRoundsRemaining = timeBetweenRounds;
    }

    void enemySpawning()
    {
        if (rate <= 0)
        {
            // Determine where the enemy will spawn.
            if (numberOfEnemies > 0)
            {
                // Get the difference between the positions.
                //  Vector3 difference = min.position - max.position;

                // Generate a random position between those positions. 
                // If random is 0, then position is min. If 1, then max.
                //  Vector3 new_difference = difference * UnityEngine.Random.Range(0.0f, 1.0f);

                // Store it in a new variable by subtracting
                // the new difference by the first position.
                // Vector3 randomPos = min.position - new_difference;
                
               float location = UnityEngine.Random.Range(0.0f, 1.0f);

                if(location >= 0f && location < 0.14f)
                {
                     spawnAt = topLeft.position;
                }
                else if (location >= 0.14f && location < 0.28f)
                {
                    spawnAt = topMiddle.position;
                }
                else if (location >= 0.28f && location < 0.42f)
                {
                    spawnAt = topRight.position;
                }
                else if (location >= 0.42f && location < 0.56f)
                {
                    spawnAt = leftTop.position;
                }
                else if (location >= 0.56f && location < 0.70f)
                {
                    spawnAt = leftBottom.position;
                }
                else if (location >= 0.70f && location < 0.84f)
                {
                    spawnAt = rightTop.position;
                }
                else
                {
                    spawnAt = rightBottom.position;
                }

                //  GameObject selectedEnemy = pickEnemy();
                GameObject selectedEnemy = pickEnemy();
                while(selectedEnemy == null)
                {
                    selectedEnemy = pickEnemy();
                }


                // Instantiate the enemy prefab
                GameObject clone = Instantiate(selectedEnemy, spawnAt, Quaternion.identity);
                numberOfEnemies--;

                // Decrease the rate so enemies spawn faster
                rate = setrate - spawnRate;

                // Do not let the difficulty rise too high.
                // If so, enemies will spawn faster than we
                // will be able to realistically handle.
                if (spawnRate >= setrate / 2)
                {
                 //   diff = setrate / 2;
                }
                // If not too difficult, increment difficulty.
                else
                {
                   // diff += diff;
                }
            }
            // Decrement rate timer.
        }
        else
        {
            rate--;
        }
        
    }

    GameObject pickEnemy()
    {
            {
                int temp = UnityEngine.Random.Range(0, 4);
                GameObject selectedEnemy = listOfEnemies[temp];

               
               

                if (selectedEnemy == basicEn)
                {
                    if (numberOfBasic > 0)
                    {
                        numberOfBasic--;
                        return selectedEnemy;

                    }
                }
                else if (selectedEnemy == fastEn)
                {
                    if (numberOfFast > 0)
                    {
                        numberOfFast--;
                        return selectedEnemy;
                    }
                }
                else if (selectedEnemy == explodeEn)
                {
                    if (numberOfExplode > 0)
                    {
                        numberOfExplode--;
                        return selectedEnemy;
                    }
                }
                else if (selectedEnemy == shootingEn)
                {
                    if (numberOfShooting > 0)
                    {
                        numberOfShooting--;
                        return selectedEnemy;
                    }

                }







                return null;
            }



        }
}


