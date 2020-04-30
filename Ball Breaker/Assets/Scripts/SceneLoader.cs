using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// need to use this namespace as we are loading scenes
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // use scenemanager class to get the current active scene, via the GetActiveScene method
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

       // Load the next scene using existing scene + 1
       SceneManager.LoadScene(currentSceneIndex + 1);             
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
