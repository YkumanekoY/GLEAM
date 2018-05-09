using UnityEngine;
using System.Collections;


public class LumpScript : MonoBehaviour {
	
	bool lightUp = false;
	public static int lightCount = 3;

	public GameObject Light; 
	GameObject LClone;
	public GameObject enemy;


	private int mapX=0;
	private int mapZ=0;

	//キャラ特性
	private int[] LPos = { 1, -1 };

	// Use this for initialization
	void Start () {
		
	}

	void OnUserAction(){

		Vector3 myTransform = this.transform.position;

		Debug.Log ("x:" + myTransform.x + " y:" + myTransform.y + " z:"+ myTransform.z);
		Debug.Log (mapX + "," + mapZ);

		//点いてなくて且点灯上限までいってないとき点灯
		if (lightUp == false && lightCount > 0) {
			lightUp = true;
			lightCount--;
			Debug.Log ("OK");

			//光源生成して子オブジェクトに移動させる
			for (int i = 0; i < LPos.Length; i++) {

				LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
				LClone.transform.parent = transform;

				LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
				LClone.transform.parent = transform;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				Debug.Log (mapX + "," + mapZ);
				AStar.map [mapX, mapZ] = 1;


				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];

				Debug.Log (mapX + "," + mapZ);
				AStar.map [mapX, mapZ] = 1;

			}

			//マップ情報更新
			AStar d2=enemy.GetComponent<AStar>();
			//if (!d2.gameObject.active)
			//	d2.gameObject.SetActive (true);
			d2.ReStart ();

		} 
		//点灯している場合消灯
		else if (lightUp == true) {


			lightUp = false;
			lightCount++;
			Debug.Log ("down");

			//子オブジェクト全削除
			foreach ( Transform child in gameObject.transform )
			{
				GameObject.Destroy(child.gameObject);
			}

			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				AStar.map [mapX, mapZ] = 0;


				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				AStar.map [mapX, mapZ] = 0;

			}

			AStar d2=enemy.GetComponent<AStar>();
			//if (!d2.gameObject.active)
			//	d2.gameObject.SetActive (true);
			d2.ReStart ();
			}

	} 
}