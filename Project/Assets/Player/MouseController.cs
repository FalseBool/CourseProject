using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float sensX=3f;
    public float sensY=3f;

    public float minX = -360;
    public float maxX = 360;
    public float minY = -90;
    public float maxY = 90;

    private Quaternion originalRot;
    private float RotX = 0;
    private float RotY = 0;

    //private float xvelocity = 0;
    //private float yvelocity = 0;
    //public float snappiness= 1;
    [SerializeField]
    private Camera cam = null;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        originalRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        RotX += Input.GetAxis("Mouse X") * sensX;
        RotY += Input.GetAxis("Mouse Y") * sensY;

        RotX %= 360;
        RotY %= 360;

        RotX = Mathf.Clamp(RotX, minX, maxX);
        RotY = Mathf.Clamp(RotY, minY, maxY);

        //RotX = Input.GetAxis("Mouse X") * sensX;
        //RotY -= Input.GetAxis("Mouse Y") * sensY;

        //xVelocity = Mathf.Lerp(xVelocity, RotX, snappiness * Time.deltaTime);
        //yVelocity = Mathf.Lerp(yVelocity, RotY, snappiness * Time.deltaTime);


        ////RotY
        //RotY = Mathf.Clamp(RotY, -maxY, maxY);
        //cam.transform.localRotation = Quaternion.Euler(yVelocity, 0, 0);

        ////RotX
        //transform.Rotate(0, xVelocity, 0);

        Quaternion yQuaternion = Quaternion.AngleAxis(RotY , Vector3.left);
        Quaternion xQuaternion = Quaternion.AngleAxis(RotX , Vector3.up);
        transform.localRotation = originalRot * xQuaternion ;
        cam.transform.localRotation = originalRot * yQuaternion;
    }
    public void AddRecoil(float side,float Up)
    {
        RotX += side;
        RotY += Up;
    }
}
