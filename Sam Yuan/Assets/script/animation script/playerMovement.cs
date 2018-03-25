using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	//this to get the animator
	public Animator anim;


	//some input getters
	private float inputH;
	private float inputV;


	// Use this for initialization
	void Start () {
		//get the animator.
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space")) {
			//-1 for the layer base layer
			//0f is when how far through the animation do we switch
			anim.Play ("jump",-1,0f);
		}
		else if (Input.GetKey ("2")) {
			anim.Play ("stop",-1,0f);
		}

		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");

		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
	}
}
