using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Array of enemy prefabs to spawn
    public int numberOfEnemies = 5;     // Number of enemies to spawn
    public float spawnRadius = 10f;     // Radius within which enemies will be spawned

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calculate a random position within the spawn radius
            Vector2 randomPos = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPos.x, 0f, randomPos.y) + transform.position;

            // Randomly select an enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instantiate the selected enemy prefab at the random position
            GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);

            // Optionally, you can set up additional configurations for the spawned enemy here
            // For example, you might want to set a parent for organization or apply other properties.

            // Debug.Log("Enemy spawned at: " + spawnPosition);
        }
    }
}
