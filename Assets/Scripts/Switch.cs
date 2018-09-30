using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public bool pressed=false;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player")
			pressed = true;
		Debug.Log ("Pressed Switch");
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player")
			pressed = false;
	}
}