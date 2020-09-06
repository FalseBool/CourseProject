using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bird : AIController
{
    private float offset = 0f;
    public float range = 20f;
    public float ScaleMin = 1f;
    public float ScaleMax = 2f;
    //public float angle = 10f;
    public float lookRate = 15f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        float scale = Random.Range(ScaleMin, ScaleMax);
        Vector3 scaleVec = new Vector3(scale, scale, scale);
        transform.localScale = scaleVec;
        GetComponentInChildren<ParticleSystem>().transform.localScale = scaleVec;
        GetComponentInChildren<SkinnedMeshRenderer>().materials[0].color = GenerateColor();  //смена цвета
        GetComponentInChildren<SkinnedMeshRenderer>().materials[3].color = GenerateColor();

        StartCoroutine("FindPath");

    }


    Color GenerateColor() {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }
    IEnumerator FindPath()
    {
        for (;;)
        {
            agent.SetDestination(findPoint());
            yield return new WaitForSeconds(lookRate);
        }
    }

    Vector3 findPoint() //Держится на костылях (переделать)
    {
        offset = (Random.Range(-range, range)); //тут был angle
        Vector3 Target = transform.position + transform.forward * range + transform.right * offset;
        UnityEngine.AI.NavMeshHit hit;
        if (agent.Raycast(Target, out hit))
        {
            offset = Mathf.Abs(offset); //если видит стену сварачивает вправо
            Target = transform.position + transform.forward * range + transform.right * offset;
            if(agent.Raycast(Target, out hit))
            {
                offset = Mathf.Abs(offset) * -1;//если справа стена сворачивает влево
                Target = transform.position + transform.forward * range + transform.right * offset;
            }
        }
        Debug.DrawLine(transform.position, Target, Color.red, 1f);
        return Target;
    }


    public override void OnDie()
    {
        base.OnDie();
        Destroy(gameObject);
    }
}
