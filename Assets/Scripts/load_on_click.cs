using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_on_click : MonoBehaviour {

    public void LoadByIndex(int index) {
        SceneManager.LoadScene(index);
        //load another Scene
    }
}
//whole class written by Zhehu Yuan
