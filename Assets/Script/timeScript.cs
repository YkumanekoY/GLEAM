using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour {
	
	private float time = 15;

	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = ((int)time).ToString();
	}
	
	// Update is called once per frame
	void Update () {

		time -= Time.deltaTime;
		if (time < 0)
			SceneManager.LoadScene ("Clear");
		GetComponent<Text> ().text = ((int)time).ToString ();
	}
}
