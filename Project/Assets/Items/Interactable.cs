using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    //public GameObject ToInteract;
    public GameObject puzzleToSpawn = null;

    public delegate void ActivateDelegate();
    public event ActivateDelegate activateEvent;
    //При взаимодеисвии
    public virtual void OnInteract()
    {

        print("Interact with " + gameObject);
        if (puzzleToSpawn == null)
        {
            ActivateAllSubs(true);
        }
        else
        {
            PlayerManager.instance.uiManager.GetComponent<UiManager>().SpawnUi(puzzleToSpawn, gameObject);
        }

    }

    public void ActivateAllSubs(bool canActiv)
    {
        if( canActiv & activateEvent != null)
        {
            activateEvent();
        }
    }
    public bool haveSubs()
    {
        return (activateEvent != null);
    }

}
