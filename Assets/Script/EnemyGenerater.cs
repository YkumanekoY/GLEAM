using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {

	public GameObject enemy;
	private int count=0;
	public float timeOut;
	public float timeElapsed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timeElapsed += Time.deltaTime;

		if (timeElapsed >= timeOut) {


			Instantiate (enemy, new Vector3 (1, 0, 9), Quaternion.identity);

			timeElapsed = 3.6f;
			count ++;
		}

		if (count == 3) {
			Destroy (this);
		}

	}
}