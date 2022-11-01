using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public GameObject[] startTilePrefabs;
    private float spawnPos=0;
    private float tileLength = 20;
    private int startTiles = 6;
    [SerializeField] private Transform player;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        SpawnStartTile();
        for (int i=0;i<startTiles;i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
    }

    void Update()
    {
        if (player.position.z-20 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile= Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void SpawnStartTile()
    {
        GameObject nextTile = Instantiate(startTilePrefabs[0], transform.forward * spawnPos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
