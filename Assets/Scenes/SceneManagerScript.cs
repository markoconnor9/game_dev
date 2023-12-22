// NOTE: If the box above this text note says anything
// other than Assembly-CSharp, autofill will NOT work.
// Unity functions and syntax can be tedious, and it is
// common to make mistakes in commands when there is no guide.

// Library Imports are used to access many of Unity's
// built in C# functions to make game programming easy.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Here is a new library we will include
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    // create a static version of this class so we can access
    // this class from any script in this game without having
    // to reference it first.
    public static SceneManagerScript instance;
    public static int classValue = 0;
    private void Awake()
    {
        // set the instance to this class
        instance = this;

        // use this to prevent object destruction on scene changes.
        DontDestroyOnLoad(gameObject);
    }

    // An enum holds a list of constants, in this case it
    // is the names of our scenes. When you add your scenes to
    // the enum, make sure they line up with the index of the added
    // scenes that is listed within the build settings.
    public enum Scene
    {
        titleScreen,
        map1,
        endScreen,
        classSelection,
        gameWin
    }

    public void isButtonPressed()
    {
        Debug.Log("pressed button");
    }

    // Load a specific scene
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    // Load the first level
    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.map1.ToString());
    }

    // Load the Main Menu
    public void LoadEndScreen()
    {
        SceneManager.LoadScene(Scene.endScreen.ToString());
    }
    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(Scene.titleScreen.ToString());
    }

    // Load the next scene based on the index in the build settings
    public void LoadNextScene()
    {
        // get the currently active scene and open the next one in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame()
    {
        Application.Quit();

    }
    public void playerWon()
    {
        SceneManager.LoadScene(Scene.gameWin.ToString());
    }

    public void selectClass()
    {
        SceneManager.LoadScene(Scene.classSelection.ToString());
    }

    public void loadAsMage()
    {
        classValue = 1;
        SceneManager.LoadScene(Scene.map1.ToString());
    }
    public void loadAsKnight()
    {
        classValue = 2;
        SceneManager.LoadScene(Scene.map1.ToString());
    }
    public void loadAsRouge()
    {
        classValue = 3;
        SceneManager.LoadScene(Scene.map1.ToString());
    }
}
