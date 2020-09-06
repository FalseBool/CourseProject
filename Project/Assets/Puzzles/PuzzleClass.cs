using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleClass : MonoBehaviour
{

    public GameObject CalledFrom;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void endOfPuzzle(bool success)  //Завершение пазла (Должно быть у абстрактного класса)
    {

        CalledFrom.GetComponent<Interactable>().ActivateAllSubs(success);
        Destroy(gameObject);
        PlayerManager.instance.uiManager.GetComponent<UiManager>().ContinueTime();
    }
    // Update is called once per frame
    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //endOfPuzzle(false);
        }
    }
}
