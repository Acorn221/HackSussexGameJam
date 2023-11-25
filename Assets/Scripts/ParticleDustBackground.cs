using UnityEngine;
using System.Collections;

public class ParticleDustBackground : MonoBehaviour
{
    public GameObject dustParticlePrefab; // Prefab of the dust particle
    public int numberOfParticles = 100;   // Number of particles in the system
    public float particleSpeed = 1f;      // Speed of particles
    public float particleLifetime = 5f;   // Time each particle will live

    void Start()
    {
        // Start the continuous spawning coroutine
        StartCoroutine(SpawnParticlesContinuously());
    }

    // Coroutine for continuous spawning
    IEnumerator SpawnParticlesContinuously()
    {
        while (true)
        {
            // Instantiate particles
            for (int i = 0; i < numberOfParticles; i++)
            {
                InstantiateParticle();
            }

            // Wait for a short duration before spawning the next set of particles
            yield return new WaitForSeconds(1f);
        }
    }

    void InstantiateParticle()
    {
        // Instantiate a particle at a random position within the camera's viewport
        Vector3 randomViewportPosition = new Vector3(Random.value, Random.value, transform.position.z);
        Vector3 randomWorldPosition = Camera.main.ViewportToWorldPoint(randomViewportPosition);
        GameObject particle = Instantiate(dustParticlePrefab, randomWorldPosition, Quaternion.identity);

        // Parent the particle to the camera
        particle.transform.parent = transform;

        // Set a random speed for each particle
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        particle.GetComponent<Rigidbody2D>().velocity = randomDirection * particleSpeed;

        // Schedule the destruction of the particle after a certain time
        Destroy(particle, particleLifetime);
    }
}