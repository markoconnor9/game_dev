using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject sceneManager;
    // Start is called before the first frame update
    public void endingGame()
    {
        sceneManager.GetComponent<SceneManagerScript>().LoadEndScreen();
        
    }

   // void OnDestroy()
    //{
        //create a paramter to tell the game the player died or i ended the scene manually
       // sceneManager.GetComponent<SceneManagerScript>().LoadEndScreen();
    //}
}
