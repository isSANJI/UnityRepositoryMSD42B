﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    GameObject[] blocksArray;

    GameObject randomBlock;

    Vector2 startingPosition, blockPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        blockPosition = startingPosition;

        LoadAndGetRandomBlocks();
    }

    private void LoadAndGetRandomBlocks()
    {
        //load all Blocks in array from Resources folder
        blocksArray = Resources.LoadAll<GameObject>("Blocks");

        for (int y = 5; y > 1; y--)
        {
            for (int x = 1; x <= 8; x++)
            {
                //generate a random Block from the array
                int randomNumber = Random.Range(0, blocksArray.Length);
                randomBlock = blocksArray[randomNumber];

                Instantiate(randomBlock, blockPosition, transform.rotation);
                blockPosition.x += 2;
            }

            blockPosition.x = startingPosition.x;
            blockPosition.y -= 2;


        }
        
    }

    
}
