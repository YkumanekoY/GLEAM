using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetScript : MonoBehaviour {

	public GameObject cube;
	public GameObject town;
	public GameObject wallBlock;
	public GameObject Lump;
	private int[,] trapSetMap;

	// Use this for initialization
	void Start () {

		trapSetMap = MapSet.stageArray;
		
		for (int i = 0; i < trapSetMap.GetLength(0); i++) {
			for (int j = 0; j < trapSetMap.GetLength(1); j++) {
				if (trapSetMap[i,j] == 0) {
					if (i == 5 && j == 5) {
						Instantiate (town, new Vector3 (i, -1, j), Quaternion.identity);
						trapSetMap [i, j] = 4;
					} else {
						Instantiate (cube, new Vector3 (i, -1, j), Quaternion.identity);
					}
				}else {
					Instantiate(wallBlock, new Vector3(i, -1, j), Quaternion.identity);
					trapSetMap [i, j] = 0;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
