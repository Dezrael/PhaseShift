using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Chunk currentChunk;
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private float spawnOffset;
    [SerializeField] private float chunksCount;
    private List<Chunk> activeChunks = new List<Chunk>();

    void Start()
    {
        activeChunks.Add(currentChunk);
    }

    void Update()
    {
        if(player.position.x > currentChunk.end.position.x - spawnOffset)
        {
            PlaceChunk();
        }
    }

    private void PlaceChunk()
    {
        Chunk newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
        newChunk.transform.position = currentChunk.end.position - newChunk.begin.localPosition;
        activeChunks.Add(newChunk);
        currentChunk = newChunk;

        if(activeChunks.Count > chunksCount)
        {
            Destroy(activeChunks[0].gameObject);
            activeChunks.RemoveAt(0);
        }
    }
}
