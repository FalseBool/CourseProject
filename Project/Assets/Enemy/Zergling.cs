using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zergling : EnemyController
{

    private Animator animCtrl;
    bool isAttacking = false;
    bool seenPlayer = false;
    public LayerMask m_LayerMask;
    public float biteRadius = 1f;
    public GameObject bitePoint = null;



    public bool enableDebugSphere = false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        if (GetComponentInChildren<Animator>() != null)
        {
            animCtrl = GetComponentInChildren<Animator>();
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        float distance = Vector3.Distance(Target.position, transform.position);
        if (distance <= lookRadius)
        {
            seenPlayer = true;
        }
        if (seenPlayer && !isAttacking)
        {
            agent.destination = Target.position;
            if (animCtrl != null)
            {
                animCtrl.SetBool("IsRunning", true);
            }
        }
        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            if (!isAttacking)
            {
                RaycastHit hit;
                Debug.DrawRay(transform.position, transform.forward * agent.stoppingDistance, Color.green, 1f);
                if (Physics.Raycast(transform.position, transform.forward, out hit, agent.stoppingDistance))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        isAttacking = true;
                        animCtrl.SetBool("IsAttacking", true);
                    }
                }
            }
        }
    }

    public override void Attack()
    {

        Collider[] hitColliders = Physics.OverlapSphere(bitePoint.transform.position, biteRadius, m_LayerMask);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log("Hit : " + hitColliders[i].name + i);
            if (hitColliders[i].GetComponent<Health>() != null)
            {
                hitColliders[i].GetComponent<Health>().TakeDamage(damage);
            }
            
            i++;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (enableDebugSphere)
            Gizmos.DrawWireSphere(bitePoint.transform.position, biteRadius);
    }
    public override void OnDie()
    {
        base.OnDie();
        Destroy(gameObject);
    }
    public void ResetAttack()
    {
        isAttacking = false;
        animCtrl.SetBool("IsAttacking", false);
    }
}
