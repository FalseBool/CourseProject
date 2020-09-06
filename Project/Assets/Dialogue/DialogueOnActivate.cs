using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnActivate : ActivatableClass
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    public override void Activate()
    {
        base.Activate();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
