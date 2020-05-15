using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration
    [SerializeField] AudioClip blockBreakSound;
    [SerializeField] GameObject blockParticleVFX;  
    // create an array of sprites to show damage level
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    LevelManager level;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    private void Start()
    {
        // method to count breakable blocks
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        // need to actually set the cached reference as it's currently null
        level = FindObjectOfType<LevelManager>();


        // this method is called for every block in the game scene
        // it runs a method in LevelManager that increments a number each time it runs
        // so if you had 2 blocks in the scene it will be called twice (once for every block).
        // the level manager stores the value
        // use tags to ensure we are counting only breakable blocks
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // use tags to ensure we are destroying only breakable blocks
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        // if not reached max hit, then show the next damage sprite
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit -1;    
        // check to make sure that the sprite has a sprite index
        if (hitSprites[spriteIndex] != null)
        {
            // gets the specific component of the gameobject 
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Block sprite is missing from damage array" + gameObject.name);
        }

    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();

        // use the cached instance of level to destroy a block 
        level.DecrementBlockCount();
        TriggerBlockParticle();
        // local game object inherited from the component
        // shortcut used to give you a GameObject the script is attached to (in this case a block)
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        // . creating an audiosource, not getting an audiosourcecomponent
        AudioSource.PlayClipAtPoint(blockBreakSound, Camera.main.transform.position);
        // when the block is destroyed, run add to score method in GameStatus
        FindObjectOfType<GameSession>().AddToScore();
    }

    private void TriggerBlockParticle()
    {
        // instantiating a game object - in this case the particle effect, at the position of the block transform
        // creates a reference of the object in this case sparkles so that it can be tidied up easily below
        GameObject sparkles = Instantiate(blockParticleVFX, transform.position, transform.rotation);
        
        // tidy up the object by destroying it after 1 second
        //sparkles.SetActive(false);
        Object.Destroy(sparkles, 1f);
    }
}
