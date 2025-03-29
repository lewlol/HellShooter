using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Dead
        }
    }
}
