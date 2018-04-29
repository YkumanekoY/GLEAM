using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreat : MonoBehaviour {

	public GameObject cube;

	float xPos=0;
	float yPos=0;

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i<9; i++) {
			for (int j=0; j<9; j++) {
				GameObject.Instantiate (cube, new Vector2 (xPos, yPos), new Quaternion ());
				yPos += cube.transform.localScale.y;

			}
			yPos = 0;
			xPos += cube.transform.localScale.x;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
