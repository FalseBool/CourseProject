using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageLight : ActivatableClass
{
   public Color color;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Activate()
    {

        GetComponent<Light>().color = color;
        base.Activate();
    }
}
