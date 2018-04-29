using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreat : MonoBehaviour {

	public GameObject cube;
	public GameObject town;

	int input_tate=9;	//マップ縦
	int input_yoko=9;	//マップ横	フィールドで入れられたらいいね

	float xPos=0; //スタート位置
	float yPos=0; //スタート位置

	int[,] array_MapList = new int[9,9];	//マップ配列

	// Use this for initialization
	void Start () {
		
		for (int i = 0; i<input_yoko; i++) {
			for (int j=0; j<input_tate; j++) {
				
				if (i == 4 && j == 4) {
					GameObject.Instantiate (town, new Vector2 (xPos, yPos), new Quaternion ());
					array_MapList [4, 4] = 4 ;
				} else {
					GameObject.Instantiate (cube, new Vector2 (xPos, yPos), new Quaternion ());
				}

				yPos += cube.transform.localScale.y;
				//array_MapList [i, j] = 0;

			}
			yPos = 0;
			xPos += cube.transform.localScale.x;
		}


		Debug.Log (array_MapList);

	}
	
	// Update is called once per frame
	void Update () {


		if (OnTouchDown ()) {
			Debug.Log ("タップされました");//タップ判定
		}

	}

	bool OnTouchDown(){

		if (0 < Input.touchCount) {

			for (int i = 0; i < Input.touchCount; i++) {
				
				Touch t = Input.GetTouch (i);

				if (t.phase == TouchPhase.Began) {
					Ray ray = Camera.main.ScreenPointToRay (t.position);
					RaycastHit hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {

						if (hit.collider.gameObject == this.gameObject) {
							return true;
						}
					}

				}

			}
		}	//タップ判定
		return false;
	}

}
