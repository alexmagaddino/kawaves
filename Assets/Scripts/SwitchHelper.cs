using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHelper : MonoBehaviour {

	public bool doppio;
	public bool pressed = false;
	public Switch SwicthOnePressed;
	public GameObject porta;

	// Use this for initialization
	void Start (){
	}

	// Update is called once per frame
	void Update () {
		if (!doppio) {
			if (pressed)
				porta.GetComponent<CosoDaAttivareScrt> ().Apri ();
		}else{
			if (pressed && SwicthOnePressed.GetComponent<Switch> ().pressed == true)
				porta.GetComponent<CosoDaAttivareScrt> ().Apri ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player")
			pressed = true;
	}

	void OnTriggerExit2D(Collider2D col){
			pressed = false;
	}


}
