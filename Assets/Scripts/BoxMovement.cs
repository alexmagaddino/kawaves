using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {

	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player2" && col.gameObject.name != "Player1")
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        else GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
}
