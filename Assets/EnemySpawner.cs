using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemyPrefabs;
    
    [SerializeField]
    public int numberOfEnemies = 5;
    
    [SerializeField]
    public float spawnRadius = 10f;

    void SpawnEnemies()
    {
        if (enemyPrefabs.Length == 0)
        {
            return;
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject newEnemy = Instantiate(randomEnemyPrefab);
            float randomScale = Random.Range(0.5f, 2f);
            newEnemy.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}
