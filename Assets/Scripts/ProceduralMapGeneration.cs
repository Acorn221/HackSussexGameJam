using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProceduralMapGeneration : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject playerPrefab;
    public GameObject cameraPrefab;
    public int mapWidth = 10;
    public int mapHeight = 10;

    void Start()
    {
        GenerateMap();
        InstantiatePlayerAndCamera();
    }

    void GenerateMap()
    {
        // Create an empty game object as a parent for the map objects
        GameObject mapParent = new GameObject("MapObjects");

        // Add a Rigidbody2D component to the mapParent
        Rigidbody2D mapRigidbody = mapParent.AddComponent<Rigidbody2D>();
        mapRigidbody.bodyType = RigidbodyType2D.Static; // Set the body type to Static

        // Create a list to hold individual colliders
        List<BoxCollider2D> colliders = new List<BoxCollider2D>();

        // Instantiate walls on the perimeter of the map and add colliders to the list
        for (int x = 0; x < mapWidth; x++)
        {
            colliders.Add(CreateWall(x, 0, mapParent.transform));
            colliders.Add(CreateWall(x, mapHeight - 1, mapParent.transform));
        }

        for (int y = 1; y < mapHeight - 1; y++)
        {
            colliders.Add(CreateWall(0, y, mapParent.transform));
            colliders.Add(CreateWall(mapWidth - 1, y, mapParent.transform));
        }

        // Create a composite collider and assign it to the mapParent
        CompositeCollider2D compositeCollider = mapParent.AddComponent<CompositeCollider2D>();
        compositeCollider.geometryType = CompositeCollider2D.GeometryType.Polygons;

        // Enable the composite collider
        compositeCollider.usedByEffector = true;

        // Add all individual colliders to the composite collider and set the layer to "Obstacle"
        foreach (var collider in colliders)
        {
            collider.transform.SetParent(mapParent.transform); // Set the collider's parent to mapParent
            collider.usedByEffector = true; // Enable the collider for use by an Effector (if needed)
            collider.gameObject.layer = LayerMask.NameToLayer("Obstacle"); // Set the layer to "Obstacle"
        }
    }

    BoxCollider2D CreateWall(int x, int y, Transform parent)
    {
        GameObject wall = Instantiate(wallPrefab, new Vector3(x, y, 0), Quaternion.identity, parent);
        BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
        collider.offset = Vector2.zero;
        collider.size = new Vector2(1, 1);

        return collider;
    }


    void InstantiatePlayerAndCamera()
    {
        // Instantiate player prefab as a child of the mapParent
        GameObject player = Instantiate(playerPrefab, new Vector3(1, 1, 0), Quaternion.identity);

        // Instantiate camera prefab as a child of the mapParent
        GameObject camera = Instantiate(cameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);

        if (camera != null)
        {
            camera.GetComponent<DynamicCameraScript>().target = player.transform;
        }
        else
        {
            Debug.LogError("Camera component not found on the cameraPrefab.");
        }

    }
}