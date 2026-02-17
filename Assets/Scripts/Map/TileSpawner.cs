using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> tileSpawnLocations;
    [SerializeField] private List<GameObject> tilesToSpawn;
    [SerializeField] private int gridWidth = 5;
    [SerializeField] private int gridHeight = 5;
    [SerializeField] private float tileSize = 25f;

    void Start()
    {
        if (tileSpawnLocations.Count == 0) return;

        Vector3 center = tileSpawnLocations[0].transform.position;

        for (int x = -1; x <= 1; x++)
        {
            for (int z = -1; z <= 1; z++)
            {
                GameObject randomTile = tilesToSpawn[Random.Range(0, tilesToSpawn.Count)];

                Vector3 spawnPosition = center + new Vector3(
                    x * tileSize,
                    0,
                    z * tileSize
                );

                Instantiate(randomTile, spawnPosition, Quaternion.identity);
            }
        }
    }
}
