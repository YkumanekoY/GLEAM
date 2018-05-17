using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownScript : MonoBehaviour {

	public static int Hp=3;
	private bool gameOver;
	GameObject enemy;

	// Use this for initialization
	void Start () {
		gameOver = false;
		Hp = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Hp == 0) {
			if (gameOver == false) {
				var clones = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (var clone in clones) {
					Destroy (clone);
				}

				FadeController.scene = 4;
				FadeController.isFadeOut = true;
				gameOver = true;
			}
		}		
	}
}
