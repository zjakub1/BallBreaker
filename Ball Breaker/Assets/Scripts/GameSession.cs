using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // this class is used to control the speed of the game
    // added as an game object to the scene so to allow it control
    // config
    // Range creates a contrained slider in this case allows us to change time speed in the UI
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;

    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    
    // singleton pattern, set not to destroy the previous game object
    // the single pattern applies to any children - so if you drag a game object, it will apply to that too
    // in this case we have done this to gamecanvas > score text
    // awake is called before anything else
    private void Awake()
    {
        // get number of object types of GameStatus
        // the method returns a list but we are just getting a length (int) back
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        //if there are more than one (one already exists)
        if (gameStatusCount > 1)
        {
            // destroy this one
            // set active is something to do with timing
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // so there is not already a game object
            // don't destroy yourself if a level loads in the future          
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // allows us to control time
        Time.timeScale = gameSpeed;       
    }

    // method to update score
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    
}
