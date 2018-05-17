using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {
	
	//　出現させる敵を入れておく
	[SerializeField] GameObject[] enemys;
	//　次に敵が出現するまでの時間
	[SerializeField] float appearNextTime;
	//　この場所から出現する敵の数
	[SerializeField] int maxNumOfEnemys;
	//　今何人の敵を出現させたか
	private int numberOfEnemys;
	//　待ち時間計測フィールド
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		numberOfEnemys = 0;
		elapsedTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//　この場所から出現する最大数を超えてたら何もしない
		if (numberOfEnemys >= maxNumOfEnemys) {
			return;
		}
		//　経過時間を足す
		elapsedTime += Time.deltaTime;

		//　経過時間が経ったら
		if (elapsedTime > appearNextTime) {
			elapsedTime = 0f;

			AppearEnemy ();
		}
	}

	void AppearEnemy() {
		//　出現させる敵をランダムに選ぶ
		var randomValue = Random.Range (0, enemys.Length);

		//出現場所をランダムで指定
		/*int pos1 = Random.Range (0, 3);
		int startX = 0;
		int startZ = 0;
		var startPos =new Vector3();

		if (pos1 == 0) {
			startX = Random.Range (0, 10);
			startPos = new Vector3 (startX, 0, 0);
		} else if (pos1 == 1) {
			startZ = Random.Range (0, 10);
			startPos = new Vector3 (0, 0, startZ);
		} else if (pos1 == 2) {
			startX = Random.Range (0, 10);
			startPos = new Vector3 (startX, 0, 10);
		} else if (pos1 == 3) {
			startZ = Random.Range (0, 10);
			startPos = new Vector3 (10, 0, startZ);
		}*/

		//　敵の向きをランダムに決定
		//var randomRotationY = Random.value * 360f;
		//Debug.Log(startPos);
		GameObject.Instantiate (enemys[randomValue], new Vector3(0,0,0), Quaternion.Euler (45f, -45f, 0f));


		numberOfEnemys++;
		elapsedTime = 0f;
	}

}