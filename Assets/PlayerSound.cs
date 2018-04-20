using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

	public AudioClip jumpSound;

	public AudioSource source;
	public float volLowRange = .5f;
	public float volHighRange = 1.0f;

	// Use this for initialization
	void Awake () {

		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump")) 
		{
			source.PlayOneShot (jumpSound, 1F);
			
		}
		
	}
}
