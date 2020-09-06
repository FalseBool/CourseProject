using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSens = 3f;

    [SerializeField]
    private PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //Calculate movement velocity as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;
        //Final movmet vector
        Vector3 _velocity = (_moveHorizontal+ _movVertical).normalized * speed;
        //Apply movement
        motor.Move(_velocity);

        //Calc rotation
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, Mathf.Clamp(_yRot,-90,90), 0f) * lookSens;
        
        //apply rot
        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _CameraRotation = new Vector3(Mathf.Clamp(_xRot, -90, 90), 0f, 0f) * lookSens;
        
        motor.CameraRotate(_CameraRotation);
    }
}
