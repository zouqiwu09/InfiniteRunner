using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager> {
       
    // a object queue that is used to store generated ground
    protected Queue<GameObject> mGroundPool = new Queue<GameObject>();

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
