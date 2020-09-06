using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrlUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    public float walkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float speed = 8.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Vector3 velocity;
    public Vector3 pubVelocity;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (controller.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            velocity = moveDirection * speed;
            pubVelocity = controller.velocity;

            if (Input.GetButton("Jump"))
                velocity.y = jumpSpeed;   //сделать прыжок по кривой
        }
        Debug.DrawLine(transform.position, transform.position + velocity, Color.yellow, 0.1f);

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
