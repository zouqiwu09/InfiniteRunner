using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Qiwu Zou  (start as 3/24 but continue to update until 4/30)
public class ObjectManager : Singleton<ObjectManager> {
       
    // a object queue that is used to store generated ground
    protected Queue<GameObject> mGroundPool = new Queue<GameObject>();

    // Init when the game replays
    public void init()
    {
        mGroundPool.Clear();
    }
    public void addGround (GameObject ground)
    {
        mGroundPool.Enqueue(ground);
    }

    public int groundCount()
    {
        return mGroundPool.Count;
    }

    public void deleteGround()
    {
        UnityEngine.Object.Destroy(mGroundPool.Dequeue().transform.parent.gameObject);
    }

}
