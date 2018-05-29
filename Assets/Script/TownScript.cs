using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownScript : MonoBehaviour {

	public static int Hp=3;
	private bool gameOver;
	GameObject enemy;
	GameObject town1;
	GameObject town2;
	GameObject town3;

	// Use this for initialization
	void Start () {
		town1 = GameObject.Find ("town1");
		town2 = GameObject.Find ("town2");
		town3 = GameObject.Find ("town3");
		town1.SetActive (true);
		town2.SetActive (true);
		town3.SetActive (true);
		gameOver = false;
		Hp = 3;

	}
	
	// Update is called once per frame
	void Update () {
		if (Hp == 2) {
			town3.SetActive (false);
		}
		else if(Hp == 1){
			town2.SetActive (false);
		}
		else if (Hp == 0) {
			if (gameOver == false) {
				
				var clones = GameObject.FindGameObjectsWithTag ("Enemy");
				foreach (var clone in clones) {
					Destroy (clone);
				}
				town1.SetActive (false);
				FadeController.scene = 4;
				FadeController.isFadeOut = true;
				gameOver = true;
			}
		}		
	}
}
