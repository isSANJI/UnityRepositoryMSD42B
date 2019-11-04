using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        //when blocks == 0 load next scene
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }

    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
}
