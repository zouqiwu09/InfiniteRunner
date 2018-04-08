using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	public Transform prefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++)
		{
			Instantiate(prefab, new Vector3(Random.Range(0,10),0,Random.Range(0,10)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
