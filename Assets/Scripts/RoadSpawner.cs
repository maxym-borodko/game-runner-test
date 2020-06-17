using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //
    [SerializeField] RoadBlock startRoadBlock;
    [SerializeField] RoadBlock roadBlockPrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;

    [Range(0, 100)]
    [SerializeField] int numberOfBlocksForward = 15;

    [Range(0, 100)]
    [SerializeField] int numberOfBlocksBehind = 4;

    //
    List<RoadBlock> roadBlocks = new List<RoadBlock>();

    //
    PlayerControl player;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();

        if (startRoadBlock != null)
        {
            roadBlocks.Add(startRoadBlock);
        }

        InitBlocks();
    }

    void LateUpdate()
    {
        CheckForSpawn();
    }

    //
    private void InitBlocks()
    {
        for (int i = 0; i < numberOfBlocksForward + numberOfBlocksBehind - 2; i++)
        {
            SpawnNextBlock();
        }
    }

    private void CheckForSpawn()
    {
        if (roadBlocks.Count == 0 ) { return; }

        //
        var first = roadBlocks[0];

        if (player.transform.position.z - first.transform.position.z >= roadBlockPrefab.BlockLength() * numberOfBlocksBehind)
        {
            //
            SpawnNextBlock();
            //
            DestroyLastBlock(first);
        }
    }

    private void SpawnNextBlock()
    {
        var last = roadBlocks[roadBlocks.Count - 1];
        Vector3 blockPosition = last.transform.position + Vector3.forward * roadBlockPrefab.BlockLength();
        RoadBlock newBlock = Instantiate(roadBlockPrefab, blockPosition, Quaternion.identity);
        newBlock.transform.parent = transform;
        roadBlocks.Add(newBlock);

        GenerateObjectsForBlock(newBlock);
    }

    private void GenerateObjectsForBlock(RoadBlock block)
    {
        // Math
        //block.PutObject(Instantiate(coinPrefab), 0, 0);
        //block.PutObject(Instantiate(coinPrefab), 0, 1);
        //block.PutObject(Instantiate(coinPrefab), 0, 2);

        //block.PutObject(Instantiate(coinPrefab), 1, 0);
        block.PutObject(Instantiate(coinPrefab), 1, 1);
        block.PutObject(Instantiate(obstaclePrefab), 2, 1);

        //block.PutObject(Instantiate(coinPrefab), 2, 0);
        //block.PutObject(Instantiate(coinPrefab), 2, 1);
        //block.PutObject(Instantiate(coinPrefab), 2, 2);
    }

    private void DestroyLastBlock(RoadBlock first)
    {
        Destroy(first.gameObject);
        roadBlocks.Remove(first);
    }
}
