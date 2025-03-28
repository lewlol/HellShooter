using UnityEngine;

public class EnemySingleSpawner : MonoBehaviour
{
    public Enemy[] enemies;

    private void Awake()
    {
        int rEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[rEnemy].enemyPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
