using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;

public class block : MonoBehaviour {
    bool touch_by_user = false;
    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
    // Use this for initialization
    void Start () {
        byte[] bs = new byte[8];
        rng.GetBytes(bs);
        int value = BitConverter.ToInt32(bs, 0);
        value = value % 10;
        if (value < 0) value = -value;
        // safe random number

        if (value < 20)
        {
            Destroy(this);
        }
        else touch_by_user = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this);
    }
    private void OnDestroy()
    {
        
    }
}
