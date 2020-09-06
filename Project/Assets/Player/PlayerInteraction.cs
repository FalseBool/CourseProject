using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float rangeOfTrace = 5f;
    [SerializeField]
    private Camera cam = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward* rangeOfTrace, Color.blue, 1f);
            InteractLine();
        }
    }
    void InteractLine()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rangeOfTrace))
        {

            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
            else
            {
                //Debug.Log("Not Interactable");
            }
        }
    }
}
