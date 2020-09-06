using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableClass : MonoBehaviour
{
    public GameObject Caller = null;

    // Start is called before the first frame update
    public virtual void Start()
    {
        if (Caller != null)
        {
            Caller.GetComponent<Interactable>().activateEvent += Activate;
        }
    }
    public virtual void  Activate()
    {
        Debug.Log("Activate Event call in " + gameObject);
        if (Caller.GetComponent<Interactable>()!=null)
        {
            Caller.GetComponent<Interactable>().activateEvent -= Activate;
        }
    }

}
