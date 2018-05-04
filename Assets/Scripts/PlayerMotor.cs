
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Qiwu Zou completed the animation logic, jump logic, game start logic, collison logic (4/29)
 * Yuqing Gu wrote the distance method on 3/26/18,final unit testing and bug-fixes were accomplished by Qiwu Zou on 4/29/18
 * Ye Tian wrote character running logic (4/29)
 *
 *
 *
 *
 *
 */
public class PlayerMotor : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;

    public float speed = 6.0F;
    public float jumpSpeed = 16.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public Text distanceText;
    public float pushPower = 2.0F;

    public float distance = 0f;
    // set up a distance variable
    Vector3 lastPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position;
    }

    void Update()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Roll", false);

        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded && anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
            //Removed
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

                moveDirection.y = jumpSpeed;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime;

        if (GameManager.Instance.isStarted())
        {
            anim.SetBool("Run", true);
            //Move
            controller.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            controller.Move(new Vector3(0,0,0));

        }

  
        distance += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        SetDistanceText();
    }

    //Logic when hitting (for jump)
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        anim.SetBool("Jumping", false);
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        //Jump
        body.velocity = pushDir * pushPower;
    }

    // display distance
    void SetDistanceText()
    {
        distanceText.text = "Distance:" + distance.ToString();
    }

    //Removed
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
