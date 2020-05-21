using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    //public variables
    Vector2 paddlePos;

    // Configuration parameters
    [SerializeField] float screenUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f ;

    // cached references
    // factor find object of type out from updates as it can be expensive
    GameSession session;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        // factor find object of type out from updates as it can be expensive
        // only need to do it once
        // reference a link from the objects to the variables
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Get current x and why transform postion of the paddle
        paddlePos = new Vector2(transform.position.x, transform.position.y);
        // set x to be the UI value within a range of floats, don't want it to go lower than 1 or higher than 15 
        // so that the sprite doesn't go out of the screen bounds
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;             
    }

    private float GetXPos()
    {
        if (session.isAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            // Get the UI value of the paddle, based on the proportion of x mouse cursor and screen width
            return Input.mousePosition.x / Screen.width * screenUnits;
        }
    }

    public Vector2 GetPaddlePosition()
    {
        return paddlePos;
    }
}
