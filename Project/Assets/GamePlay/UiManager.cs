using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private float tScale = 0.0000001f;// timeScale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnUi(GameObject ToSpawn, GameObject parent)
    {
        Instantiate(ToSpawn);
        ToSpawn.GetComponent<PuzzleClass>().CalledFrom = parent;  //Эта строчка пременима только к пазлам а нужно ко всем Ui
        StopTime();
    }

    public void StopTime()
    {
        Time.timeScale = tScale;
    }
    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

}
