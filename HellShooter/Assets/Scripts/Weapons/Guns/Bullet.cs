using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
