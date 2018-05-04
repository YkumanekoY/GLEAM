using UnityEngine;
using System.Collections;


public class LumpScript : MonoBehaviour {
	
	//public static bool GameStart;
	bool lightUp = false;
	public static int lightCount = 1;
	//private Vector3 clickPosition;
	public GameObject light; 

	// Use this for initialization
	void Start () {

	}
	void OnUserAction(){

		Vector3 myTransform = this.transform.position;

		Debug.Log ("x:" + myTransform.x + " y:" + myTransform.y + " z:"+ myTransform.z);
		if (lightUp == false && lightCount > 0) {
			lightUp = true;
			lightCount--;
			Debug.Log ("OK");
		
			Instantiate(light, myTransform + new Vector3(1,1,0), light.transform.rotation);
			Instantiate(light, myTransform + new Vector3(-1,1,0), light.transform.rotation);
			Instantiate(light, myTransform + new Vector3(0,1,1), light.transform.rotation);
			Instantiate(light, myTransform + new Vector3(0,1,-1), light.transform.rotation);
		} else if (lightUp == true) {
			lightUp = false;
			lightCount++;
			Debug.Log ("down");
			}

	} 
}