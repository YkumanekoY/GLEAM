﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {
	
	//　出現させる敵を入れておく
	[SerializeField] GameObject[] enemys;
	//　次に敵が出現するまでの時間
	private float appearNextTime;
	//　この場所から出現する敵の数
	[SerializeField] int maxNumOfEnemys;
	//　今何人の敵を出現させたか
	private int numberOfEnemys;
	//　待ち時間計測フィールド
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		appearNextTime = 4f;
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
	
		GameObject.Instantiate (enemys[randomValue], new Vector3(0,0,0), Quaternion.Euler (45f, -45f, 0f));

		numberOfEnemys++;
		elapsedTime = 0f;

		if (numberOfEnemys == 10) {
			appearNextTime = 2.5f;
		} else if (numberOfEnemys == 25) {
			appearNextTime = 1f;
		}
	}

}