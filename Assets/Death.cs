﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
            if (col.gameObject.name == "pawn")
            {
                GameManager.Instance.getFullHealth();
                ObjectManager.Instance.init();
                SceneManager.LoadScene(14);
        }
        
    }
}
