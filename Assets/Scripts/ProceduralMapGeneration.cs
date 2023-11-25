using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapGeneration : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject wallPrefab; // Prefab for wall
    public GameObject pelletPrefab; // Prefab for pellets
    public Transform mapContainer; // Parent object for the generated map elements

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Create walls on the edges
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity, mapContainer);
                }
                else
                {
                    // Create open paths and pellets in the center
                    Instantiate(pelletPrefab, new Vector3(x, y, 0), Quaternion.identity, mapContainer);

                    // Adjust the condition based on your maze generation logic
                    if (Random.Range(0f, 1f) > 0.7f)
                    {
                        Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity, mapContainer);
                    }
                }
            }
        }
    }
}