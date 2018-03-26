using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan_ground : MonoBehaviour {
	private bool canSpawn = true;
	private Vector3 targetPosition;
    public int maximum = 3;
	// Use this for initialization
	void Start () {
        ObjectManager.Instance.addGround(this.gameObject);
        Debug.Log(ObjectManager.Instance.groundCount());
        if (ObjectManager.Instance.groundCount() > maximum)
        {
            ObjectManager.Instance.deleteGround();
        }
		//targetPosition = this.gameObject.transform.parent.Find("body").transform.position + new Vector3 (0, 140, 0);
	}
	
	void Update () {
		
		//this.gameObject.transform.parent.Find("body").transform.position = Vector3.MoveTowards (transform.position, targetPosition, 0.05f);
		
	}

	void OnTriggerEnter(Collider col){ 
		if (canSpawn) {
			if (col.gameObject.name == "pawn") {
				Transform temp_trans = this.gameObject.transform.parent.transform;
				Vector3 tempV3 = temp_trans.position + new Vector3 (0, 0, 27);
				GameObject nextCube = Instantiate (Resources.Load ("basicGround") as GameObject, tempV3, temp_trans.rotation); 
				canSpawn = false;
			} else {
				Debug.Log (col.gameObject.name);
			}
		}
	}
		
}
