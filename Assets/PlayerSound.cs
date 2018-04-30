using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

	public AudioClip jumpSound;

	public AudioSource source;
	public float volLowRange = .5f;
	public float volHighRange = 1.0f;
    public Animator anim;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && anim.GetCurrentAnimatorStateInfo(0).IsName("Run")) 
		{
			source.PlayOneShot (jumpSound, 1F);
			
		}
		
	}
}
