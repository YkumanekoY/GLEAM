using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	public Texture[] PlayerTexture;
	public float fps = 24;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

/*		var index : int = Time.time * framesPerSecond;
		index = index % frames.Length;
		guiTexture.texture = frames[index];*/

		if( Input.GetMouseButtonDown(0) ) 
		{ 
			Vector2 point = Camera.main.ScreenToWorldPoint( Input.mousePosition ); 
			Collider2D collition2d = Physics2D.OverlapPoint( point ); 
			if( collition2d ) 
			{ 
				Debug.Log( collition2d.gameObject.name.ToString() );
				SceneManager.LoadScene("PlayerSerect");
			} 
		} 
	}
}
