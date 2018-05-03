using UnityEngine;
using System.Collections;


public class LumpScript : MonoBehaviour {

	bool lightUp = false;
	int lightCount = 0;

	// Use this for initialization
	void Start () {

	}
	public void OnUserAction()
	{
		if (lightUp == false && lightCount > 0) {

			lightUp = true;
		
		} else {
			lightUp = false;
			lightCount++;
		}
		Debug.Log ("LightClick!");
	} 
}