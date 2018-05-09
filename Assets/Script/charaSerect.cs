using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class charaSerect : MonoBehaviour {

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
		Debug.Log (player);
	}

	public void charaB(){
		player = 2;
		Debug.Log (player);
	}

	public void charaC(){
		player = 3;
		Debug.Log (player);
	}

	public void StartBotton(){
		if (player == 0) {
			Debug.Log ("No!");
		} else {
			SceneManager.LoadScene ("Map");
		}

	}
}
