using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour {
    public float Speed;
    public Vector2 jumpVelocity,jumpVelocityJ;
    public bool GND;
    public int Vita = 20;
    public Animator anim;
    public float Walking = 0f;
    GameObject Player2;
    public AudioClip Jump;
    public AudioSource Source;
	int KoJ;
    
    void Start()
    {
        anim=gameObject.GetComponent<Animator>();
        Player2 = GameObject.Find("Player2");
		KoJ = PlayerPrefs.GetInt ("KoJ");
    }

	void Update () {
		if (KoJ == 0) {
			Speed = Input.GetAxis ("Horizontal1");
			//anim.SetFloat ("Walking", Mathf.Abs (Speed));
			if (Speed < -0.1f)
				transform.localScale = new Vector3 (-0.3f, 0.3f, -1);
			else if (Speed > 0.1)
				transform.localScale = new Vector3 (0.3f, 0.3f, -1);
			if (GND == true)
				transform.Translate (Speed * Time.deltaTime * 5, 0, 0);
			else
				transform.Translate (Speed * Time.deltaTime * 4f, 0, 0);
			if (Input.GetKeyDown (KeyCode.W))
			if (GND == true) {
				Source.clip = Jump;
				Source.Play ();
				GetComponent<Rigidbody2D> ().AddForce (jumpVelocity, ForceMode2D.Force);
			}
		} else {
			Speed = Input.GetAxis ("Horizontal 1J");
			//anim.SetFloat ("Walking", Mathf.Abs (Speed));
			if (Speed < -0.1f)
				transform.localScale = new Vector3 (-0.3f, 0.3f, -1);
			else if (Speed > 0.1)
				transform.localScale = new Vector3 (0.3f, 0.3f, -1);
			if (GND == true)
				transform.Translate (Speed * Time.deltaTime * 5, 0, 0);
			else
				transform.Translate (Speed * Time.deltaTime * 4f, 0, 0);
			if (Input.GetButton("A Button"))
			if (GND == true) {
				Source.clip = Jump;
				Source.Play ();
				GetComponent<Rigidbody2D> ().AddForce (jumpVelocity, ForceMode2D.Force);
			}
		}
		if (Vita >= 21) {
			Vita = 20;
		}
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.tag == "Player" && obj.transform.position.y + 0.5f < transform.position.y)
        {
			Player2.transform.position = new Vector3 (transform.position.x,transform.position.y+1,0);
        }

        if (obj.gameObject.tag == "Projectile")
            Vita -= 15;

        if (obj.gameObject.tag == "Caduta")
        {
            Destroy(GameObject.Find("PLAYER(Clone)"));
            Destroy(GameObject.Find("PLAYER"));
        } 
    }

    void OnCollisionStay2D(Collision2D col)
    {
		if (col.collider.tag == "Pavimento")
			GND = true;
		else
			GND = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
            GND = false;
    }
}
