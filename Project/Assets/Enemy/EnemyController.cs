using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : AIController
{
    public float lookRadius = 10f;
    public float smoothOfRot = 3f;
    public float damage = 10f;
    protected Transform Target;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Target = PlayerManager.instance.Player.transform;

    }

    // Update is called once per frame
    public virtual void Update()
    {
        /*
        float distance = Vector3.Distance(Target.position, transform.position);
        if(distance <= lookRadius )
        {
            agent.destination = Target.position;

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (Time.time >= nextTimeToAttack)
                {
                    nextTimeToAttack = Time.time + 1f / AttackRate;
                    RaycastHit hit;
                    Debug.DrawRay(transform.position, transform.forward* agent.stoppingDistance, Color.green, 1f);
                    if (Physics.Raycast(transform.position, transform.forward , out hit, agent.stoppingDistance))
                    {
                        if (hit.transform.CompareTag("Player"))
                        {
                            Attack();

                        }
                    }
                }
            }
        }
        */
    }
    public virtual void Attack()
    {

    }
    public virtual void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothOfRot);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRadius);
    }
}
