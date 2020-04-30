using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    // declared paddle, to allow us to get transform location
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;


    // state - created Vector2 to be able to store paddle transform details
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // set storage vector to be the difference between the current transform (ball) and the paddle transform
        // this is for the delta
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        { 
            LockBall(); 
            LaunchOnMouseClick();
        }
        
    }

    private void LockBall()
    {
        // create new vector for the paddle
        Vector2 paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        /// use paddle vector + delta and assign it to the ball - this means the ball will stay a fixed distance from the paddle
        transform.position = paddlepos + paddleToBallVector;
    }

    public void LaunchOnMouseClick()
    {        
        if (Input.GetMouseButton(0))
        {
            hasStarted = true;
            // get the objects rigidbody velocity component
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        }
    }
}
