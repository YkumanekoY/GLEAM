using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class LumpScript : MonoBehaviour {
	
	bool lightUp = false;
	public static int Count = 3;

	Slider slider;

	public GameObject Light; 
	GameObject LClone;
	GameObject[] enemyC;

	private int mapX=0;
	private int mapZ=0;

	//キャラ特性
	private int[] LPos = { 1, -1 };

	// Use this for initialization
	void Start () {
		
		enemyC = GameObject.FindGameObjectsWithTag("Enemy");
		slider = GameObject.Find("energy").GetComponent<Slider>();
		slider.maxValue = charaSerect.lightCount;
		slider.minValue = 0;
		slider.value = charaSerect.lightCount;

	}


	void OnUserAction(){
		
		Vector3 myTransform = this.transform.position;

		Debug.Log ("x:" + myTransform.x + " y:" + myTransform.y + " z:"+ myTransform.z);
		Debug.Log (mapX + "," + mapZ);

		//点いてなくて且点灯上限までいってないとき点灯
		if (lightUp == false && Count > 0) {
			
			lightUp = true;
			Count--;
			slider.value--;
			Debug.Log ("OK"+Count);
			Type (myTransform);

		} 
		//点灯している場合消灯
		else if (lightUp == true) {

			lightUp = false;
			Count++;
			slider.value++;
			Debug.Log ("down"+Count);
			TypeB(myTransform);

			//子オブジェクト全削除
			foreach (Transform child in gameObject.transform) {
				GameObject.Destroy (child.gameObject);
			}

		}
	} 

	void Type(Vector3 myTransform){
		if (charaSerect.player == 1) {
			
				//光源生成して子オブジェクトに移動させる
				for (int i = 0; i < LPos.Length; i++) {

					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
					LClone.transform.parent = transform;

					LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;

					mapX = (int)myTransform.x + LPos [i];
					mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 1;


					mapX = (int)myTransform.x;
					mapZ = (int)myTransform.z + LPos [i];

				MapSet.stageArray [mapX, mapZ] = 1;

				}

				enemyC = GameObject.FindGameObjectsWithTag("Enemy");
				//マップ情報更新
				AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
				foreach(var d in d2)
				{
					d.ReStart ();
				}
			return;
			
		}else if (charaSerect.player == 2) {
			
			//光源生成して子オブジェクトに移動させる
			for (int i = 0; i < LPos.Length; i++) {

				LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, LPos[i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (-1 * LPos[i], 0,LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

			}

			enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}
			return;
			
		}else if (charaSerect.player == 3) {
			for (int i = 0; i < LPos.Length; i++) {

				LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (2*LPos [i], 0, 0), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, LPos[i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, 2*LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (-1 * LPos[i], 0,LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x + 2*LPos [i];
				mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + 2*LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 1;

			}

			enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}
			return;
		}

	}

	void TypeB(Vector3 myTransform){
		if (charaSerect.player == 1) {
			
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 0;


				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 0;

			}
			return;

		}else if (charaSerect.player == 2) {
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				MapSet.stageArray [mapX, mapZ] = 0;
			}
			return;
		}else if (charaSerect.player == 3) {
				
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;

				MapSet.stageArray [mapX, mapZ] = 0;


				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];

				MapSet.stageArray [mapX, mapZ] = 0;
			}
			return;
		}

	}

}