using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (OnTouchDown ()) {
			Debug.Log ("タップされました");
		}

	}

	bool OnTouchDown(){

		if (0 < Input.touchCount) {

			for (int i = 0; i < Input.touchCount; i++) {

				Touch t = Input.GetTouch (i);

				if (t.phase == TouchPhase.Began) {
					Ray ray = Camera.main.ScreenPointToRay (t.position);
					RaycastHit hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {

						if (hit.collider.gameObject == this.gameObject) {
							return true;
						}
					}

				}

			}
		}
		return false;
	}
}
