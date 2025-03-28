using TreeEditor;
using UnityEngine;

public class EnemyMultiSpawner : MonoBehaviour
{
    public Enemy[] enemies;
    [Space]
    public int minEnemies;
    public int maxEnemies;
    [Space]
    public float enemySpawnDistance;

    private void Awake()
    {
        int enemyCount = Random.Range(minEnemies, maxEnemies);

        for(int e = 0; e < enemyCount; e++)
        {
            float spawnX = Random.Range(transform.position.x - enemySpawnDistance, transform.position.x + enemySpawnDistance);
            float spawnZ = Random.Range(transform.position.z - enemySpawnDistance, transform.position.z + enemySpawnDistance);

            Vector3 spawnLoc = new Vector3(spawnX, transform.position.y, spawnZ);

            int randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy].enemyPrefab, spawnLoc, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemySpawnDistance);
    }
}
