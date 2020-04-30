using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Configuration parameters
    [SerializeField] float screenUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX =15f ;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the UI value of the paddle, based on the proportion of x mouse cursor and screen width
        float paddleX = Input.mousePosition.x / Screen.width * screenUnits;
        // Get current x and why transform postion of the paddle
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        // set x to be the UI value within a range of floats, don't want it to go lower than 1 or higher than 15
        paddlePos.x = Mathf.Clamp(paddleX, minX, maxX);
        transform.position = paddlePos;     
    }
}
