using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int maxHits;
    [SerializeField] int timesHit = 0;

    Level level;

    GameStatus gs;

   

    void Start()
    {
        gs = FindObjectOfType<GameStatus>();

        //find object of type Level and save it in level
        level = FindObjectOfType<Level>();
        
        if (gameObject.tag == "Breakable")
        {
            //add 1 to breakableBlocks
            level.CountBreakableBlocks();
        }

    }

    private void TriggerSparklesVFX()
    {
        GameObject particles = Instantiate(blockSparklesVFX, this.transform.position, transform.rotation);
        Destroy(particles, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if(gameObject.tag=="Breakable")
        {

            //play the AudioClip from the Camera position
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            timesHit++;
            if (timesHit >= maxHits)
            {
                Destroy(gameObject);
                TriggerSparklesVFX();
                gs.AddToScore();
                level.BlockDestroyed();
            }
            else
            {
                ShowNextHitSprite();
            }


        }

        
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
