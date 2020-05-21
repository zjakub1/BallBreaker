using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // variables
    [SerializeField] float xVelocity = 0.00001f;
    [SerializeField] float yVelocity = 1f;
    [SerializeField] int yPostion = 1;
    UnityEngine.Vector2 enemyPosition;
    [SerializeField] float enemySpeed = 1f;
    [SerializeField] GameObject enemySparkles;

    // cached objects
    Paddle paddle;
    GameSession session;

    GameObject enemyPrefab;
    GameObject enemyInstance;

    UnityEngine.Vector2 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        session = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (session.getHasStarted())
        {
            MoveTowardsPlayer();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {     
        if (session.getHasStarted())
        {
            KillPlayer(collision);
        }
    }

    public void MoveTowardsPlayer()
    {

        playerPosition = new UnityEngine.Vector2(paddle.transform.position.x, paddle.transform.position.y);
        //transform.position = enemyPosition;
        // move the enemy towards the player
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, playerPosition, enemySpeed * Time.deltaTime);
    }


    private void KillPlayer(Collider2D collision)
    {
        
        // for now we only want objects with this tag to end the game if it hits the collider
        if (collision.tag == "Player")
        {
        
            SceneManager.LoadScene(3);
        }
        // if the ball hits the enemy kill the enemy object
        if (collision.tag == "Player Ball")
        {
            Debug.Log(" COLL tag" + collision.tag);
            GameObject sparkles = Instantiate(enemySparkles, transform.position, transform.rotation);
            Object.Destroy(sparkles, 1f);
            Object.Destroy(gameObject);
        }
    }

}
