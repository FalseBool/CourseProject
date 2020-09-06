using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilGun : MonoBehaviour
{

    //public GameObject Weapon;
    public float maxRecoil_x = -20.0f;
    public float maxRecoil_y = -10.0f;

    public float maxTrans_x = 1.0f;
    public float maxTrans_z = -1.0f;

    public float recoilSpeed = 10.0f;

    //public bool isfire = false;

    private float timer;
    public float time = 1;

    void Update()
    {
        if (timer > 0)
        {
            Quaternion maxRecoil = Quaternion.Euler(Random.Range(transform.localRotation.x, maxRecoil_x),Random.Range(transform.localRotation.y, maxRecoil_y),transform.localRotation.z);

            // Dampen towards the target rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);

            //Vector3 maxTranslation = new Vector3(Random.Range(transform.localPosition.x, maxTrans_x),transform.localPosition.y,Random.Range(transform.localPosition.z, maxTrans_z));

            //transform.localPosition = Vector3.Slerp(transform.localPosition, maxTranslation, Time.deltaTime * recoilSpeed);
            timer -= Time.deltaTime* recoilSpeed;
        }

    }
    public void resetTimer()
    {
        timer = time;
    }
}
