using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class charaSerect : MonoBehaviour {

	public static int lightCount = 0; //一度に点けられる量
	public static int lightHave = 0; //配置できる数
	public static int player = 0;//キャラA:1 B:2 C:3

	public GameObject help;
	GameObject sound;

	// Use this for initialization
	void Start () {
		FadeController.isFadeIn = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void charaA(){
		
		player = 1;

		lightCount = 4;
		lightHave = 6;

	}

	public void charaB(){
		player = 2;

		lightCount = 3;
		lightHave = 8;
	}

	public void charaC(){
		player = 3;

		lightCount = 2;
		lightHave = 4;
	}

	public void StartBotton(){
		if (player == 0) {
			
			Debug.Log ("No!");

		} else {
			SceneManager.LoadScene ("Map");
			Debug.Log (player + "," + lightCount + "," + lightHave );
		}

	}

	public void BackBotton(){
		
		sound = GameObject.Find ("Sound");
		mainSound d1 = sound.GetComponent<mainSound> ();
		d1.DontDestroyEnabled = false;

		Destroy(sound);
		SceneManager.LoadScene ("Title");
	}

	public void PushDown(){
		help.SetActive (true);
	}

	public void PushUp(){
		help.SetActive(false);
	}
}
