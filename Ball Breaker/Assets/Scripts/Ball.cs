/*
 * using System.Collections;
using System.Collections.Generic;
*/
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    // declared paddle, to allow us to get transform location
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomBounce = 0.2f;


    // state - created Vector2 to be able to store paddle transform details
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // cached component references
    // more efficient to get the component once rather than for each collision
    AudioSource myAudioSource;
    // creating a cached reference to rigidBody2D
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        // set storage vector to be the difference between the current transform (ball) and the paddle transform
        // this is for the delta
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        // getting the rigidBody reference
        myRigidBody2D = GetComponent<Rigidbody2D>();
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
            // get the objects rigidbody velocity component and set x and y velociity
            myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // tweaking the velocity so that we don;t get boring bits
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomBounce), Random.Range(0f, randomBounce));

        if (hasStarted)
        {
            // set the clip to be a random value within the ballSounds array
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            // audiosource is the component that allows audio (audioclip) to be played
            myAudioSource.PlayOneShot(clip);
            // alter the velocity by a random amount
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
