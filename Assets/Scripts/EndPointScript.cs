using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    // Tag to identify the player GameObject
    public string playerTag = "Player";

    // Prefix for scene names (e.g., "Scene" + 1 = "Scene1")
    public string sceneNamePrefix = "Scene";

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag(playerTag))
        {
            // Load the next scene if available
            LoadNextScene();
        }
        Destroy(GameObject.Find("Player"));
    }

    void LoadNextScene()
    {
        // Get the current active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the index of the next scene
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene exists
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            Debug.Log(sceneNamePrefix + nextSceneIndex);
            SceneManager.LoadScene(sceneNamePrefix + nextSceneIndex);
        }
        else
        {
            // Optionally, handle the case when there is no next scene (end of the game)
            Debug.LogWarning("No next scene available. End of the game.");
            Destroy(GameObject.Find("Player"));
        }
    }
}