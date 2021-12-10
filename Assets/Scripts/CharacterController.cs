using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterController : MonoBehaviour
{
    public UnityEngine.CharacterController controller;
    //public Rigidbody rb;

    public Transform cam;
    private Vector3 direction = Vector3.zero    ;

    public Joystick joystick;

    public float speed = 8;
    //public float jumpForce = 10;
    public float gravity = -30;
    public bool grounded;

    float Horizontal = 0f;
    float Vertical = 0f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 Velocity;

    public PhotonView view;

    /*private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }*/
    // Update is called once per frame
    void Update()
    {
        /*if (view.IsMine)
        {*/
        grounded = controller.isGrounded;

        if (grounded && Velocity.y < 0)
        {
             Velocity.y = 0f;
        } 

        //float xInput = Input.GetAxisRaw("Horizontal");
        Horizontal = joystick.Horizontal * speed;
        //direction.x = xInput * speed; //x axis movement

        //float zInput = Input.GetAxisRaw("Vertical");
        Vertical = joystick.Vertical * speed;
        //direction.z = zInput * speed; //x axis movement

        //direction = new Vector3(Horizontal, rb.velocity.y, Vertical);//.normalized;
        direction = new Vector3(Horizontal, 0f, Vertical);//.normalized;
        direction.y += gravity * Time.deltaTime; //gravity

        //rb.velocity = direction;

       if (direction.magnitude >= 0.1f)
       {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(direction * speed * Time.deltaTime);
       }
        //}

    }
}
