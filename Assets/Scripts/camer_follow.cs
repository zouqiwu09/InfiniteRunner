using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Qiwu Zou  (3/24)
//Camera will keep following the character

public class camer_follow : MonoBehaviour {

	public GameObject target; 

	private Vector3 offset;
	// Use this for initialization
	void Start () {
        // Compute the offset
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        // Update the position
		transform.position = target.transform.position + offset;
	}
}
