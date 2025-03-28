using UnityEngine;

public class WispAI : MonoBehaviour
{
    Transform target;
    Rigidbody rb;

    public Enemy wispData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(target != null)
        {
            //Detect when to Attack
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if(distanceToPlayer <= wispData.attackRadius)
            {
                AttackPlayer();
            }
        }
        else
        {
            //Detect a Target
            DetectTarget();
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            //Movement in FIXED UPDATE to regulate movement to FPS
            ChasePlayer();
        }
    }

    private void DetectTarget()
    {
        //Detect nearby Colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, wispData.targetDetectRadius);
        foreach(Collider col in colliders)
        {
            if(col.transform.tag == "Player") //If it is a Player -- Set it to Target
            {
                target = col.transform.parent;
            }
        }
    }

    private void ChasePlayer()
    {
        //Find the Direction
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        //Add Velocity to Rigidbody
        rb.linearVelocity = direction * wispData.moveSpeed;

        //Look at Player
        transform.LookAt(target);
    }

    private void AttackPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, wispData.attackRadius + 0.25f);
        foreach (Collider col in colliders)
        {
            if (col.transform.tag == "Player") //If it is a Player -- Set it to Target
            {
                //col.transform.parent.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, wispData.targetDetectRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, wispData.attackRadius);
    }
}
