using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{

    public float blockSize = 22.86f;
    public int startBlocks = 10;
    public float distanceToGenerate = 10f;
    public Transform firstBlock;
    public GameObject blockPrefab;
    public GameObject[] obstablePrefabs;
    public GameObject goldPrefabs;
    public GameObject player;


    private Vector3 lastPosition;
    // Use this for initialization
    void Start ()
    {
        lastPosition = firstBlock.position;
        if (blockPrefab != null)
        {
            for (int i = 0; i < startBlocks; i++)
            {
                Spawn();
            }
        }
     
	}
	
	// Update is called once per frame
	void Update ()
	{


	    OptimizeGenerateBlock();

	}


    void Spawn()
    {
        //var go = Instantiate(blockPrefab) as GameObject;
        var newPos = lastPosition + new Vector3(0, 0, blockSize);
        ObjectPool.Instance.SpawnFromPool("Block", newPos, Quaternion.identity);
        //go.transform.position = lastPosition + new Vector3(0, 0, blockSize);
        lastPosition = newPos;
    }


    void OptimizeGenerateBlock()
    {
        if (player == null)
            return;
        var distance = Vector3.Distance(lastPosition, player.transform.position);
        //print("player distance: "+distance);
        if (distance < distanceToGenerate)
        {
            Spawn();
            ObstableManager.Instance.Respawn(lastPosition);
        }
    }
}
