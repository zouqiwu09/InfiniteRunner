using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour {

    public Image heart;
    public static void Hurt() {
        GameManager.Instance.hp--;
    }//health -1
    private void Update(){

        if (GameManager.Instance.hp > 0) {
            heart.sprite = Resources.Load(""+GameManager.Instance.hp, typeof(Sprite)) as Sprite;
            //health bar -1
        }
        else {
            GameManager.Instance.getFullHealth();
            heart.sprite = Resources.Load("" + GameManager.Instance.hp, typeof(Sprite)) as Sprite;
            ObjectManager.Instance.init();
            GameManager.Instance.clear();
            SceneManager.LoadScene(2);
            
            //die and reset healt
        }
    }
}
//whole class written by Zhehu Yuan
