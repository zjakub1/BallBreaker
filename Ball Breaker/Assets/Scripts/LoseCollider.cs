using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    // cached objects
    Ball ball;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {     
        // for now we only want objects with this tag to end the game if it hits the collider
        if (ball.tag == "Player Ball")
        {
            SceneManager.LoadScene(3);
        }        
    }

}
