using UnityEngine;

public class ModyfiedEnemySpawner : MonoBehaviour
{
    public static ModyfiedEnemySpawner Instance;

    public GameObject[] enemyPrefabs;   // Array of enemy prefabs to spawn
    public int numberOfEnemies = 5;     // Number of enemies to spawn
    public float spawnRadius = 10f;     // Radius within which enemies will be spawned

    void Start()
    {
        Instance = this;
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (enemyPrefabs.Length == 0)
        {
            return;
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Calculate a random angle
            float angle = Random.Range(0f, 360f);

            // Convert angle to radians
            float angleInRadians = angle * Mathf.Deg2Rad;

            // Calculate spawn position within a circle
            float x = spawnRadius * Mathf.Cos(angleInRadians);
            float y = spawnRadius * Mathf.Sin(angleInRadians);

            Vector3 spawnPosition = new Vector3(x, y, 0f) + transform.position;

            // Randomly select an enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Instantiate the selected enemy prefab at the random position
            GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);

            // Set a random scale for the spawned enemy
            float randomScale = Random.Range(0.5f, 2f); // Adjust the range according to your preferences
            newEnemy.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            // Optionally, you can set up additional configurations for the spawned enemy here
            // For example, you might want to set a parent for organization or apply other properties.

            // Debug.Log("Enemy spawned at: " + spawnPosition);
        }
    }
    public void SpawnEnemies(GameObject[] enemies, (float, float) minMaxSize, Transform parrent)
    {
        if (enemyPrefabs.Length == 0)
        {
            return;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            // Calculate a random angle
            float angle = Random.Range(0f, 360f);

            // Convert angle to radians
            float angleInRadians = angle * Mathf.Deg2Rad;

            // Calculate spawn position within a circle
            float x = spawnRadius * Mathf.Cos(angleInRadians);
            float y = spawnRadius * Mathf.Sin(angleInRadians);

            Vector3 spawnPosition = new Vector3(x, y, 0f) + transform.position;

            // Randomly select an enemy prefab from the array
            GameObject randomEnemyPrefab = enemies[i];

            // Instantiate the selected enemy prefab at the random position
            GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity, parrent);

            // Set a random scale for the spawned enemy
            float randomScale = Random.Range(minMaxSize.Item1, minMaxSize.Item2); // Adjust the range according to your preferences
            newEnemy.transform.localScale = new Vector3(randomScale, randomScale, 1);

            // Optionally, you can set up additional configurations for the spawned enemy here
            // For example, you might want to set a parent for organization or apply other properties.

            // Debug.Log("Enemy spawned at: " + spawnPosition);
        }
    }
}
