using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour {
	
	private float time = 60;

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = ((int)time).ToString();
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;

		if (time <= 0) {
			whiteFade.scene = 5;
			whiteFade.isWhiteFadeOut = true;
		}
		GetComponent<Text> ().text = ((int)time).ToString ();
	}

}
