using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Qiwu Zou completed the whole class (4/5)
//This class is for spawning new tracks from the first ground.

public class startPoint : MonoBehaviour {
    private bool canSpawn = true;
    private Vector3 targetPosition;
    private Transform currentTRANS;
    public int maximum = 3;
    // Use this for initialization
    void Start () {
        currentTRANS = this.gameObject.transform.parent.transform;
        targetPosition = currentTRANS.position + new Vector3(0, -14, 27);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (canSpawn)
        {
            if (col.gameObject.name == "pawn")
            {

                GameObject nextCube = Instantiate(Resources.Load("basicGround") as GameObject, targetPosition, currentTRANS.rotation);
                canSpawn = false;
            }
            else
            {
                //Debug.Log(col.gameObject.name);
            }
        }
    }

}
