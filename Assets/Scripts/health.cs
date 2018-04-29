using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour {
    private const int hp_max = 4;
    private static int hp = hp_max;
    public Image heart;
    public static void Hurt() {
        hp--;
    }
    private void Update(){
        if (hp > 0) {
            heart.sprite = Resources.Load(""+hp, typeof(Sprite)) as Sprite;
            //health -1
        }
        else {
            hp = hp_max;
            heart.sprite = Resources.Load("" + hp, typeof(Sprite)) as Sprite;
            SceneManager.LoadScene(14);
            ObjectManager.Instance.init();
            //die and reset healt
        }
    }
}
