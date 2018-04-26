using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwan_ground : MonoBehaviour {
	private bool canSpawn = true;
	private Vector3 targetPosition;
    private Transform currentTRANS;
    public Vector3 animeTarget;
    public int maximum = 3;
	// Use this for initialization
	void Start () {
        ObjectManager.Instance.addGround(this.gameObject);
        Debug.Log(ObjectManager.Instance.groundCount());
        if (ObjectManager.Instance.groundCount() > maximum)
        {
            ObjectManager.Instance.deleteGround();
        }
        currentTRANS = this.gameObject.transform.parent.transform;
        
        animeTarget = currentTRANS.position + new Vector3(0, 14, 0);
        

        StartCoroutine(rise());
		//targetPosition = this.gameObject.transform.parent.Find("body").transform.position + new Vector3 (0, 140, 0);
	}
	
	void Update () {
        
        //this.gameObject.transform.parent.Find("body").transform.position = Vector3.MoveTowards (transform.position, targetPosition, 0.05f);

    }

	void OnTriggerEnter(Collider col){ 
		if (canSpawn) {
			if (col.gameObject.name == "pawn") {
                targetPosition = currentTRANS.position + new Vector3(0, -14, 27);
                GameObject nextCube = Instantiate (Resources.Load ("basicGround") as GameObject, targetPosition, currentTRANS.rotation); 
				canSpawn = false;
			} else {
				Debug.Log (col.gameObject.name);
			}
		}
	}

    IEnumerator rise()
    {
        while (Vector3.Distance(this.gameObject.transform.parent.position,animeTarget) > 0.01f)
        {
            Debug.Log(Vector3.Distance(this.gameObject.transform.parent.position, animeTarget));
            Debug.Log(this.gameObject.transform.parent.position);
            this.gameObject.transform.parent.position = Vector3.MoveTowards(this.gameObject.transform.parent.position, animeTarget, 0.1f);
            yield return null;
        }
    }


}
