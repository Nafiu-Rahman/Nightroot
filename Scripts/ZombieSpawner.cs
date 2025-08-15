using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;  // The zombie prefab to spawn
    [SerializeField] Transform[] spawnPoints;  // Possible spawn locations
    [SerializeField] float spawnInterval = 3f; // Time between spawns
    [SerializeField] int maxZombies = 10;       // Limit for active zombies

    int currentZombieCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnZombie), 0f, spawnInterval);
    }

    void SpawnZombie()
    {
        if (currentZombieCount >= maxZombies) return;

        // Pick a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Spawn the zombie
        GameObject newZombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        currentZombieCount++;

        // Optional: Reduce count when zombie dies
        Robot zombieScript = newZombie.GetComponent<Robot>();
        // if (zombieScript != null)
        // {
        //     zombieScript.OnDeath += HandleZombieDeath;
        // }
    }

    // void HandleZombieDeath()
    // {
    //     currentZombieCount--;
    // }
}
