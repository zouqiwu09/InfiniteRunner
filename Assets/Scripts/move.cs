using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial code written by Qiwu Zou at 3/22
public class move : MonoBehaviour {

	public Rigidbody rigid;
	public int scale = 1;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		rigid.AddForce (h*scale, 0, v*scale);
	}
}
