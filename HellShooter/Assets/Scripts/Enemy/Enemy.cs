using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Info")]
    public string enemyName;
    public GameObject enemyPrefab;

    [Header("Enemy Stats")]
    public float damage;
    public float health;
    public float moveSpeed;

    public float targetDetectRadius;
    public float attackRadius;
}
