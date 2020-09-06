using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    private Camera playerCamera;
    public GameObject parent = null;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = PlayerManager.instance.Player.GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera != null)
        {
            transform.LookAt(playerCamera.transform);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parent.GetComponent<Interactable>() !=null && parent.GetComponent<Interactable>().haveSubs() )
            {
                GetComponent<Canvas>().enabled = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parent.GetComponent<Interactable>() != null && !parent.GetComponent<Interactable>().haveSubs())
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (parent.GetComponent<Interactable>() != null && parent.GetComponent<Interactable>().haveSubs())
            {
                GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
