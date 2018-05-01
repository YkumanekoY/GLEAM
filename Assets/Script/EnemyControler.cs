using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyControler : MonoBehaviour {

	private CharacterController enemyController;
	
	float speed = 3.0f;
	private float rotationSmooth = 1f;

	private Transform town;

	// Use this for initialization
	void Start () {
		town = GameObject.FindWithTag ("town").transform;
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion targetRotation = Quaternion.LookRotation (town.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
			
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
}