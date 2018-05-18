using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class LumpScript : MonoBehaviour {
	
	bool lightUp = false;
	public static int Count;

	Slider slider;

	public GameObject Light; 
	GameObject LClone;
	GameObject[] enemyC;

	/*SpriteRenderer MainSpriteRenderer;
	public Sprite StandbySprite;
	public Sprite UpSprite;*/

	private int mapX=0;
	private int mapZ=0;

	//キャラ特性
	private int[] LPos = { 1, -1 };

	//効果音
	private AudioSource up;
	private AudioSource down;

	// Use this for initialization
	void Start () {
		
		slider = GameObject.Find ("energy").GetComponent<Slider> ();

		slider.value = charaSerect.lightCount;
		Count = charaSerect.lightCount;
		slider.maxValue = charaSerect.lightCount;
		slider.minValue = 0;

		//MainSpriteRenderer.sprite = StandbySprite;

		AudioSource[] audioSources = GetComponents<AudioSource>();
		up = audioSources[0];
		down = audioSources[1];
	}


	void OnUserAction(){
		Vector3 myTransform = this.transform.position;

		Debug.Log ("x:" + myTransform.x + " y:" + myTransform.y + " z:" + myTransform.z);
		Debug.Log (mapX + "," + mapZ);

		//点いてなくて且点灯上限までいってないとき点灯
		if (lightUp == false && Count > 0) {
			
			lightUp = true;
			Count--;
			slider.value--;
			Debug.Log ("OK" + Count);
			Type (myTransform);
			//効果音
			up.PlayOneShot (up.clip);
			//スポットライト点灯
			GameObject childObject = gameObject.transform.Find("Spotlight").gameObject;
			//MainSpriteRenderer = childObject.GetComponent<SpriteRenderer> ();
			childObject.SetActive (true);
			//MainSpriteRenderer.sprite = UpSprite;


			enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}
		}
		//点灯している場合消灯
		else if (lightUp == true) {

			lightUp = false;
			Count++;
			slider.value++;
			Debug.Log ("down" + Count);
			TypeB (myTransform);
			//効果音
			down.PlayOneShot (down.clip);
			//MainSpriteRenderer.sprite = UpSprite;

			//子オブジェクト全削除
			foreach (Transform child in gameObject.transform) {
				if (child.tag != "Lump") {
					GameObject.Destroy (child.gameObject);
				} else if (child.name == "Spotlight") {
					child.gameObject.SetActive (false);
				}
			}

			enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}

		}
	}

	void Type(Vector3 myTransform){
		if (charaSerect.player == 1) {

			//光源生成して子オブジェクトに移動させる
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0){
					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
					LClone.transform.parent = transform;
					MapSet.stageArray [mapX, mapZ] = 1;
				}

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
			if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0){
					LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
					MapSet.stageArray [mapX, mapZ] = 1;
				}	

			}

			/*enemyC = GameObject.FindGameObjectsWithTag("Enemy");

			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}*/
			return;
			
		}else if (charaSerect.player == 2) {
			
			//光源生成して子オブジェクトに移動させる
			for (int i = 0; i < LPos.Length; i++) {
				
				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (-1 * LPos [i], 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

			}

			/*enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}*/
			return;
			
		}else if (charaSerect.player == 3) {
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, 0), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x + 2*LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (2 * LPos [i], 0, 0), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (LPos [i], 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + 2*LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (0, 0, 2 * LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) {
					MapSet.stageArray [mapX, mapZ] = 1;
					LClone = Instantiate (Light, myTransform + new Vector3 (-1 * LPos [i], 0, LPos [i]), Light.transform.rotation);
					LClone.transform.parent = transform;
				}

			}

			/*enemyC = GameObject.FindGameObjectsWithTag("Enemy");
			//マップ情報更新
			AStar[] d2 = enemyC.Select(astar => astar.GetComponent<AStar>()).ToArray();
			foreach(var d in d2)
			{
				d.ReStart ();
			}*/
			return;
		}

	}

	void TypeB(Vector3 myTransform){
		if (charaSerect.player == 1) {
			
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;


				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

			}
			return;

		}else if (charaSerect.player == 2) {
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;
			}
			return;
		}else if (charaSerect.player == 3) {
				
			for (int i = 0; i < LPos.Length; i++) {

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x + 2*LPos [i];
				mapZ = (int)myTransform.z;
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x + LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x;
				mapZ = (int)myTransform.z + 2*LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;

				mapX = (int)myTransform.x - LPos [i];
				mapZ = (int)myTransform.z + LPos [i];
				if (mapX <= 10 && mapX >= 0 && mapZ <= 10 && mapZ >= 0) 
					MapSet.stageArray [mapX, mapZ] = 0;
			}
			return;
		}

	}

}