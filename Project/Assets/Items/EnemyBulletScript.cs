using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float speed;
    public float damage = 10f;
    public ParticleSystem impactParticle;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        moveForward();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Trigger"))
        {
            if (collision.gameObject.GetComponent<Health>()!=null)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
            //foreach (ContactPoint contact in collision.contacts)
            //{
            //    Debug.DrawRay(contact.point, contact.normal , Color.white, 1f);
            //}
        }

        Debug.Log("bullet hit " + collision.gameObject.name);
        ContactPoint contact = collision.contacts[0];
        Debug.DrawRay(contact.point, contact.normal, Color.white, 1f);
        //Instantiate(impactParticle, transform.position, Quaternion.LookRotation(contact.normal));
        Destroy(gameObject);
    }




    public void moveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
