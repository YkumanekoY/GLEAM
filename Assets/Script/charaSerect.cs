﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class charaSerect : MonoBehaviour {

	public static int lightCount = 0; //一度に点けられる量
	public static int lightHave = 0; //配置できる数
	public static int power = 0; //点灯範囲


	public static int player = 0;

	// Use this for initialization
	void Start () {
		Debug.Log(player);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void charaA(){
		player = 1;

		lightCount = 4;
		lightHave = 6;
		power = 1;
	}

	public void charaB(){
		player = 2;

		lightCount = 3;
		lightHave = 10;
		power = 2;
	}

	public void charaC(){
		player = 3;

		lightCount = 3;
		lightHave = 4;
		power = 3;
	}

	public void StartBotton(){
		if (player == 0) {
			
			Debug.Log ("No!");

		} else {
			
			SceneManager.LoadScene ("Map");

		}

	}
}
