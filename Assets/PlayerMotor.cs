
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;

    public float speed = 6.0F;
    public float jumpSpeed = 16.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    public float pushPower = 2.0F;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Roll", false);

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
            /*if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0,30,0));

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, -30, 0));
            }*/
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Jumping", true);

                //rb.AddForce(0, 500, 0);
                moveDirection.y = jumpSpeed;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        anim.SetBool("Jumping", false);
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }

    /*private void OnControllerColliderHit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("WallRun_left", false);
            anim.SetBool("WallRun_right", false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        anim.SetBool("jumpFromLeft", false);
    }*/

}
