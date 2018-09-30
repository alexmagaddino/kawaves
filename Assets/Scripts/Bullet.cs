using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void Update()
    {
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag!="Nemico")
		Destroy (gameObject);
	}
	void OnTriggereEnter2D(Collider2D col){
		if(col.gameObject.tag!="Nemico")
		Destroy (gameObject);
	}
}
