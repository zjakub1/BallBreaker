using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int numberOfBlocks = 0; // Serialized for debugging purposes

    // cached instance
    // created as null
    SceneLoader scene;

    private void Start()
    {
        // scene is an object of type SceneLoader
        scene = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        numberOfBlocks++;
    }

    public void DecrementBlockCount()
    {        
        numberOfBlocks--;
        if (numberOfBlocks <= 0)
        {
            scene.LoadNextScene();
        }
    }


}
