using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public GameObject enemy;
	//public GameObject enemyGenerate;
	public Canvas title;
	public GameObject cube;
	public GameObject town;
	public GameObject wallBlock;
	public GameObject Lump;

	public GameObject start;


	// Use this for initialization
	void Start () {
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
		start.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartBotton(){
		Destroy (title.gameObject);
		Instantiate(enemy, new Vector3 (2, 0, 2), Quaternion.identity);
	}
}
