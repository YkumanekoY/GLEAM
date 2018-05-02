using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreat : MonoBehaviour {

	public GameObject cube;
	public GameObject town;
	public GameObject wallBlock;

	public int input_tate=9;	//マップ縦
	public int input_yoko=9;	//マップ横	フィールドで入れられたらいいね

	//float xPos=0; //スタート位置
	//float zPos=0; //スタート位置

	//ステージ配列　0:床, 1:壁
	public int[,] stageArray = new int[11,11]{
		{1,1,1,1,1,1,1,1,1,1,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,1,1,1}
	};	


	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < stageArray.GetLength(0); i++) {
			for (int j = 0; j < stageArray.GetLength(1); j++) {
				if (stageArray[i,j] == 0) {
					if (i == 5 && j == 5) {
						Instantiate (town, new Vector3 (i, -1, j), Quaternion.identity);
					} else {
						Instantiate(cube, new Vector3(i, -1, j), Quaternion.identity);
					}
				} else {
					Instantiate(wallBlock, new Vector3(i, 0, j), Quaternion.identity);

				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

}
