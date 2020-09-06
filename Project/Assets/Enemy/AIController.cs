using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    protected NavMeshAgent agent;
    protected Health Health;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if (GetComponent<Health>() != null)
        {
            Health = GetComponent<Health>();
            Health.onDamaged += OnDamageTaken;
            Health.onDie += OnDie;
            //Health.onHealed += OnHealed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnDamageTaken(float damage)
    {

    }
    public virtual void OnDie()
    {

    }
    public virtual void OnHealed(float HealAmount)
    {

    }
}
