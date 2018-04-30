using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	private bool start = false;
	private float Speed = 1;
	private float No_Object = 5;
	private string Diff = "Normal";

	public void onStart(){
		start = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Run", true);
	}

	public bool isStarted(){
		return start;
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
