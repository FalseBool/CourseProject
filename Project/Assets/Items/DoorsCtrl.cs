using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsCtrl : ActivatableClass
{
    public Animator animator = null;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Activate()
    {
        base.Activate();
        animator.SetBool("IsOpen", true);
    }
}
