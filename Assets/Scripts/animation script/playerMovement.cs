using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	//this to get the animator
	public Animator anim;


	//some input getters
	private float inputH;
	private float inputV;
    public float rotateScale;
    public float speed;
    public Rigidbody rb;
    private bool touchLeftWall = false;
    private bool touchRightWall = false;

    // Use this for initialization
    void Start () {
		//get the animator.
		anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.SetBool("Jump", false);
        /*if (Input.GetKey ("space")) {
			//-1 for the layer base layer
			//0f is when how far through the animation do we switch
			anim.Play ("jump",-1,0f);
		}
		else if (Input.GetKey ("2")) {
			anim.Play ("stop",-1,0f);
		}

		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		Debug.Log (inputV);

		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);*/

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(0, inputH*rotateScale, 0));
        transform.Translate(new Vector3(0, 0, inputV * speed));
        

        if (Input.GetKey("space"))
        {
            if (!anim.GetBool("Jumping"))
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Jumping", true);
                
                rb.AddForce(0, 500, 0);
            }

            else if (touchLeftWall)
            {
                rb.AddForce(new Vector3(0, -500, 300));
                anim.SetBool("JumpFromLeft", true);
                
            }

            else if (touchRightWall)
            {
                rb.AddForce(new Vector3(0, 500, 300));
                anim.SetBool("JumpFromRight", true);
            }

        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") {
            anim.SetBool("Jumping", false);
            anim.SetBool("WallRun_left", false);
            anim.SetBool("WallRun_right", false);
            


        }
        else if (collision.gameObject.tag == "LeftWall")
        {
            anim.SetBool("WallRun_left", true);
            touchLeftWall = true;
            
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            anim.SetBool("WallRun_right", true);
            touchRightWall = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchLeftWall = false;
        touchRightWall = false;

        anim.SetBool("jumpFromLeft", false);
		anim.SetBool("WallRun_left", false);
        anim.SetBool("jumpFromRight", false);
		anim.SetBool("WallRun_right", false);

    }
}
