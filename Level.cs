using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount;
    [SerializeField] int winCount=0;
    SceneLoader sceneloader;



    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        blockCount++;
    }
    public void DecountBlocks()
    {
        blockCount--;
        if (blockCount <= winCount)
        {
            sceneloader.LoadNextScene();
        }
    }

}
