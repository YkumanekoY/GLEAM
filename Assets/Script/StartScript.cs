using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject enemyGenerate;
	public Canvas title;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartBotton(){
		Destroy (title.gameObject);
		enemy.SetActive (true);
		//enemyGenerate.SetActive (true);
	}
}
