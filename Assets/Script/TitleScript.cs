using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetMouseButtonDown(0) ) 
		{ 
			Vector2 point = Camera.main.ScreenToWorldPoint( Input.mousePosition ); 
			Collider2D collition2d = Physics2D.OverlapPoint( point ); 
			if( collition2d ) 
			{ 
				Debug.Log( collition2d.gameObject.name.ToString() );
				GetComponent<AudioSource> ().Play();
				SceneManager.LoadScene("PlayerSerect");
			} 
		} 
	}
}
