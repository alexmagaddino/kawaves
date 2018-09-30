using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    Manager Man;
    public int ID;
	// Use this for initialization
	void Start () {
        Man = GameObject.Find("Main Camera").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D omino) {
        if(omino.gameObject.tag == "Player")
        {
            Debug.Log("Check"); 
            Man.GetComponent<Manager>().CheckPoint(ID);
        }
		
	}
}
