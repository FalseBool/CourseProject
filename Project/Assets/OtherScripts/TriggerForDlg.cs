using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForDlg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
