﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
			whiteFade.isWhiteFadeIn = true;
			FadeController.isFadeIn = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void titleBack(){

		this.GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("Title");
	}
}
