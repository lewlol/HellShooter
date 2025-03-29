using UnityEngine;

public class WispAI : MonoBehaviour
{
    Transform target;
    Rigidbody2D rb;

    //Stats
    public float moveSpeed;
    public float detectTargetRange;
    public float attackRange;
    public float damage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);
            if(distanceToPlayer > attackRange)
            {
                ChaseTarget();
            }
            else
            {
                AttackTarget();
            }
        }
        else
        {
            DetectTarget();
        }
    }

    private void DetectTarget()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, detectTargetRange);
        foreach(Collider2D collider in collisions)
        {
            if(collider.gameObject.tag == "Player")
            {
                target = collider.transform;
            }
        }
    }

    private void ChaseTarget()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        rb.linearVelocity = direction * moveSpeed;
    }

    private void AttackTarget()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D collider in collisions)
        {
            if (collider.gameObject.tag == "Player")
            {
                collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectTargetRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
