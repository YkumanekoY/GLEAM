﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownScript : MonoBehaviour {

	public int Hp=3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Damage(){
		
		Hp--;
		Debug.Log (Hp);

		if (Hp <= 0) {
			var clones = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (var clone in clones){
				Destroy(clone);
			}

			FadeController.isFadeOut = true;
			FadeController.scene = 4;
		}
	}
}
