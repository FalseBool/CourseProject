using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : ActivatableClass
{

    public Material matForChange;
    public int indexOfMatToChange;

    // Start is called before the first frame update
    public override void Start()
    {

        base.Start();   
    }

    public override void Activate()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        if (mats.Length < indexOfMatToChange)
        {
            indexOfMatToChange = 0;
        }
        mats[indexOfMatToChange] = matForChange;
        GetComponent<MeshRenderer>().materials = mats;
        base.Activate();
    }

}
