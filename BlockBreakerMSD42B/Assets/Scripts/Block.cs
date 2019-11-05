using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    Level level;

    GameStatus gs;

   

    void Start()
    {
        gs = FindObjectOfType<GameStatus>();

        //find object of type Level and save it in level
        level = FindObjectOfType<Level>();
        
        //add 1 to breakableBlocks
        level.CountBreakableBlocks();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //play the AudioClip from the Camera position
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        gs.AddToScore();
        level.BlockDestroyed();
    }
}
