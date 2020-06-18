using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //
    [SerializeField] RoadBlock startRoadBlock;
    [SerializeField] RoadBlock roadBlockPrefab;
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] GameObject[] obstaclePrefabs;

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
        // 
        int maxNumberOfCoins = 4;
        int maxNumberOfObstacles = 1;

        // Generate number of coins
        int numberOfGeneratedCoins = Random.Range(0, maxNumberOfCoins + 1);

        // Generate number of obstacles
        int numberOfGeneratedObstacles = Random.Range(0, maxNumberOfObstacles + 1);

        // Create objects
        List<GameObject> roadObjects = new List<GameObject>();

        foreach (int _ in Enumerable.Range(0, numberOfGeneratedCoins))
        {
            var prefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            roadObjects.Add(Instantiate(prefab));
        }

        foreach (int _ in Enumerable.Range(0, numberOfGeneratedObstacles))
        {
            var prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            roadObjects.Add(Instantiate(prefab));
        }

        // Get indices
        var indices = block.GetAllIndices();

        // Put objects to road object
        foreach (GameObject roadObject in roadObjects)
        {
            var position = Random.Range(0, indices.Count);
            var index = indices[position];
            block.PutObject(roadObject, index.row, index.column);
        }
    }

    private void DestroyLastBlock(RoadBlock first)
    {
        Destroy(first.gameObject);
        roadBlocks.Remove(first);
    }
}
