using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
    public GameObject grassTilePrefab;
    public GameObject overlayTilePrefab;
    public GameObject treePrefab;
    public GameObject bushPrefab;

    private int worldWidth = 46;
    private int worldDepth = 50;
    private bool[,] walkableTiles;

    private void Start()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        walkableTiles = new bool[worldWidth, worldDepth];

        for (int x = 0; x < worldWidth; x++)
        {
            for (int y = 0; y < worldDepth; y++)
            {
                GameObject tilePrefab = null;

                // Randomly decide whether to spawn a grass tile, tree, bush, or nothing
                int tileType = Random.Range(0, 4);

                switch (tileType)
                {
                    case 0:
                        tilePrefab = grassTilePrefab;
                        walkableTiles[x, y] = true;
                        break;
                    case 1:
                        tilePrefab = treePrefab;
                        walkableTiles[x, y] = false;
                        break;
                    case 2:
                        tilePrefab = bushPrefab;
                        walkableTiles[x, y] = false;
                        break;
                    default:
                        // Don't spawn anything
                        break;
                }

                if (tilePrefab != null)
                {
                    // Instantiate the tile prefab
                    Vector3 position = new Vector3(x - y, 0, x + y);
                    Instantiate(tilePrefab, position, Quaternion.identity);

                    // Spawn overlay tile if it's a grass tile
                    if (tileType == 0)
                    {
                        Instantiate(overlayTilePrefab, position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
