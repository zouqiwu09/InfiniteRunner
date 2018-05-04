using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Qiwu Zou completed the whole Game Manager System.  (start as 3/24 but continue to update until 4/30)
 * This system controlls the flow of the game from start to the end.
 *
 */
public class GameManager : Singleton<GameManager> {

	private static bool start = false;
	private float Speed = 1;
	private float No_Object = 5;
	private string Diff = "Normal";
    private const int hp_max = 4;
    public int hp = hp_max;
	public void onStart(){
		start = true;
	}

	public bool isStarted(){
		return start;
	}

    public void getFullHealth()
    {
        hp = hp_max;
    }

    public void clear()
    {
        start = false;
    }

	public void setDifficulty(float s, float n){
		Speed = s;
		No_Object = n;
	}

	public float getSpeed(){
		return Speed;
	}

	public float getNo_Object(){
		return No_Object;
	}

	public string getDifficulty(){
		return Diff;
	}

}
