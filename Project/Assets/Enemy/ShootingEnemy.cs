using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : EnemyController
{
    public float AttackRate = 15f;
    public float lifetimeOfBullet = 2;
    public GameObject bullet;
    public float speedOfBullet;
    public GameObject parent = null;
    public GameObject bulletpoint = null;
    
    private float nextTimeToAttack = 0f;
    public override void Start()
    {
        base.Start();
        agent = parent.GetComponent<NavMeshAgent>();
        Health = parent.GetComponent<Health>();
        Health.onDamaged += OnDamageTaken;
        Health.onDie += OnDie;
    }


    public override void Update()
    {
        if (Target.GetComponent<Health>().currentHealth > 0)
        {


            float distance = Vector3.Distance(Target.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.destination = Target.position;
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    if (Time.time >= nextTimeToAttack)
                    {
                        nextTimeToAttack = Time.time + 1f / AttackRate;
                        //RaycastHit hit;
                        //Debug.DrawRay(transform.position, transform.forward * agent.stoppingDistance, Color.green, 1f);
                        //if (Physics.Raycast(transform.position, transform.forward, out hit, agent.stoppingDistance))
                        //{
                        //if (hit.transform.CompareTag("Player"))
                        // {
                        Attack();
                        // }
                        //
                    }
                }
            }
        }
    }
    public override void Attack()
    {
        GameObject clone = Instantiate(bullet, bulletpoint.transform.position, transform.rotation);
        clone.GetComponent<EnemyBulletScript>().speed = speedOfBullet;
        clone.GetComponent<EnemyBulletScript>().damage = damage;
        Destroy(clone, lifetimeOfBullet);
    }
    public override void FaceTarget()
    {

        Vector3 nextPos = Target.transform.position + Target.GetComponent<ContrlUpdate>().pubVelocity * Vector3.Distance(Target.transform.position, transform.position)/speedOfBullet ;
        Vector3 newDir = (nextPos - transform.position).normalized;
        //Quaternion lookRot = Quaternion.LookRotation(newDir);

        Debug.DrawLine(bulletpoint.transform.position, nextPos, Color.blue, .1f);

        Vector3 direction = (Target.position - transform.position).normalized;
        //Quaternion lookRot = Quaternion.LookRotation(direction);


        Quaternion lookRot = Quaternion.LookRotation(new Vector3(newDir.x, direction.y, newDir.z));

        transform.rotation = lookRot;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * smoothOfRot);
    }

    public override void OnDie()
    {
        base.OnDie();
        Destroy(parent);
    }

}
