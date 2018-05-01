using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreat : MonoBehaviour {

	public GameObject cube;
	public GameObject town;

	public int input_tate=9;	//マップ縦
	public int input_yoko=9;	//マップ横	フィールドで入れられたらいいね

	float xPos=0; //スタート位置
	float zPos=0; //スタート位置

	int[,] array_MapList = new int[9,9];	//マップ配列

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i<input_yoko; i++) {
			for (int j=0; j<input_tate; j++) {
				
				if (i == (input_tate - 1) / 2 && j == (input_yoko - 1) / 2) {
					GameObject.Instantiate (town, new Vector3 (xPos, 0, zPos), new Quaternion ());
					array_MapList [(input_tate - 1) / 2, (input_yoko - 1) / 2] = 4;
				}
				else {
					GameObject.Instantiate (cube, new Vector3 (xPos, 0, zPos), new Quaternion ());
				}

				xPos += cube.transform.localScale.x;
				//array_MapList [i, j] = 0;

			}
			xPos = 0;
			zPos += cube.transform.localScale.z;
		}


		Debug.Log (array_MapList);

	}
	
	// Update is called once per frame
	void Update () {

	}

}
