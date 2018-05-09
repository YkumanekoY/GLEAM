using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	private float PosX;
	private float PosZ;

	public GameObject enemy;
	public GameObject town;

	// Use this for initialization
	void Start () {
		GameObject town = GameObject.Find("Town(Clone)");
		Debug.Log (town);
	}
	
	// Update is called once per frame
	void Update () {

		PosX = this.gameObject.transform.position.x;
		PosZ = this.gameObject.transform.position.z;

		if (PosX == 5.0f&&PosZ==5.0f) {
			Debug.Log ("c");
			Instantiate(enemy, new Vector3 (2, 0, 2), Quaternion.identity);

			town.SendMessage ("Damage");
			town.GetComponent<TownScript>().Damage();
			Destroy(this.gameObject);
		}
		
	}
}
