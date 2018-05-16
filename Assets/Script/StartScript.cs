using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject time;
	public Canvas title;
	public GameObject cube;
	public GameObject town;
	public GameObject wallBlock;
	public GameObject Lump;

	public GameObject cA;
	public GameObject cB;
	public GameObject cC;

	public GameObject start;


	// Use this for initialization
	void Start () {
		//マップ生成
		for (int i = 0; i < MapSet.stageArray.GetLength(0); i++) {
			for (int j = 0; j < MapSet.stageArray.GetLength(1); j++) {
				
				if (MapSet.stageArray [i, j] == 0) {
					Instantiate (cube, new Vector3 (i, -1, j), Quaternion.identity);
				}else if(MapSet.stageArray[i,j] == 4){
					Instantiate (town, new Vector3 (i, -1, j), Quaternion.identity);
				}else if(MapSet.stageArray[i,j] == 2 ){
					Instantiate(Lump, new Vector3(i, -1, j), Quaternion.identity);
				}else {
					Instantiate(wallBlock, new Vector3(i, 0, j), Quaternion.identity);
				}

			}
		}

		//左下キャラアイコン
		if (charaSerect.player == 1) {
			cA.SetActive (true);
			cB.SetActive (false);
			cC.SetActive (false);
		} else if (charaSerect.player == 2) {
			cA.SetActive (false);
			cB.SetActive (true);
			cC.SetActive (false);
		} else {
			cA.SetActive (false);
			cB.SetActive (false);
			cC.SetActive (true);
		}

		start.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void StartBotton(){
		Destroy (title.gameObject);
		enemy.SetActive(true);
		time.SetActive(true);
	}
}
