using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSet: MonoBehaviour {

	public GameObject cube;
	public GameObject town;
	public GameObject wallBlock;
	public GameObject Lump;


	private int have = charaSerect.lightHave;

	int oPosX = 0;
	int oPosZ = 0;

	//int input_tate=9;	//マップ縦
	//int input_yoko=9;	//マップ横	フィールドで入れられたらいいね

	//float xPos=0; //スタート位置
	//float zPos=0; //スタート位置

	//ステージ配列　0:床, 1:壁
	public static int[,] stageArray = new int[11,11];


	// Use this for initialization
	void Start () {
		stageArray = new int[11,11]{
			{0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,1,0,0,0,0,0},
			{0,0,0,0,1,1,1,0,0,0,0},
			{0,0,0,1,1,0,1,1,0,0,0},
			{0,0,0,0,1,1,1,0,0,0,0},
			{0,0,0,0,0,1,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0}
		};

		Lump.GetComponent<LumpScript> ().enabled = false;


		for (int i = 0; i < stageArray.GetLength(0); i++) {
			for (int j = 0; j < stageArray.GetLength(1); j++) {
				if (stageArray[i,j] == 0) {
					if (i == 5 && j == 5) {
						Instantiate (town, new Vector3 (i, -1, j), Quaternion.identity);
						stageArray [i, j] = 4;
					} else {
						Instantiate (cube, new Vector3 (i, -1, j), Quaternion.identity);
					}
				}else {
					Instantiate(wallBlock, new Vector3(i, -1, j), Quaternion.identity);
					stageArray [i, j] = 0;
				}
			}
		}
	}

	public float distance = 100f;

	// Update is called once per frame
	void Update () {
		GameObject result = null;

		// 左クリックされた場所のオブジェクトを取得
		if(Input.GetMouseButtonDown(0)) {

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(ray, out hit, distance)){

				result = hit.collider.gameObject;
				Debug.Log (result);

				if (result.gameObject.name == "MapCube(Clone)") {
					if (have > 0) {

						oPosX = (int)result.transform.position.x;
						oPosZ = (int)result.transform.position.z;

						stageArray [oPosX, oPosZ] = 2;
						Destroy (result.gameObject);
						Instantiate (Lump, new Vector3 (oPosX, -1, oPosZ), Quaternion.identity);
						have--;

						Debug.Log (have);
					} 
				} else if (result.gameObject.name == "Lump(Clone)") {

					oPosX = (int)result.transform.position.x;
					oPosZ = (int)result.transform.position.z;

					stageArray [oPosX, oPosZ] = 0;
					Destroy (result.gameObject);
					Instantiate (cube, new Vector3 (oPosX, -1, oPosZ), Quaternion.identity);
					have++;

					Debug.Log (have);
				}
			}
		}
	}

	public void nextButton(){
		
		if (have == 0) {
			SceneManager.LoadScene ("main");
		} 
	}



}
