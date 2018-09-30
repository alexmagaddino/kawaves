using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {
    public float Speed;
    public Vector2 jumpVelocity;
    public bool GND;
    public int Vita = 5;
    int VitaPl1;
    public float cont, timer;
    Animator anim;
    public AudioClip Jump,Healing;
	public AudioSource Source;
	int KoJ;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        cont = timer;
		KoJ = PlayerPrefs.GetInt ("KoJ");
    }

	void Update () {
		if (KoJ == 0) {
			//anim.SetFloat ("Walking", Mathf.Abs (Speed));
			cont -= Time.deltaTime;
			if (cont <= 0) {
				cont = timer;
				if (Vita < 5)
					Vita++;
			}
			Speed = Input.GetAxis ("Horizontal2");
			if (Speed < -0.1f)
				transform.localScale = new Vector3 (-0.15f, 0.15f, -1);
			else if (Speed > 0.1)
				transform.localScale = new Vector3 (0.15f, 0.15f, -1);
			if (GND == true)
				transform.Translate (Speed * Time.deltaTime * 8, 0, 0);
			else
				transform.Translate (Speed * Time.deltaTime * 4, 0, 0);
			if (Input.GetKeyDown (KeyCode.UpArrow))
			if (GND == true) {
				Source.clip = Jump;
				Source.Play ();
				GetComponent<Rigidbody2D> ().AddForce (jumpVelocity, ForceMode2D.Force);
			}
			if (Input.GetButtonDown ("Healing")) {
				CuraPlayer ();
			}
		} else {
			//anim.SetFloat ("Walking", Mathf.Abs (Speed));
			cont -= Time.deltaTime;
			if (cont <= 0) {
				cont = timer;
				if (Vita < 5)
					Vita++;
			}
			Speed = Input.GetAxis ("Horizontal 2J");
			if (Speed < -0.1f)
				transform.localScale = new Vector3 (-0.15f, 0.15f, -1);
			else if (Speed > 0.1)
				transform.localScale = new Vector3 (0.15f, 0.15f, -1);
			if (GND == true)
				transform.Translate (Speed * Time.deltaTime * 8, 0, 0);
			else
				transform.Translate (Speed * Time.deltaTime * 4, 0, 0);
			if (Input.GetButton("A Button 2"))
			if (GND == true) {
				Source.clip = Jump;
				Source.Play ();
				GetComponent<Rigidbody2D> ().AddForce (jumpVelocity, ForceMode2D.Force);
			}
			if (Input.GetButtonDown ("X Button 2")) {
				CuraPlayer ();
			}
		}
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Projectile")
            Vita -= 10;
        if (obj.gameObject.tag == "Caduta")
        {
            Destroy(GameObject.Find("PLAYER(Clone)"));
            Destroy(GameObject.Find("PLAYER"));
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
		if (col.collider.tag == "Pavimento" || col.collider.name=="Player1")
			GND = true;
		else
			GND = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        GND = false;
    }

    void CuraPlayer()
    {
        Source.clip = Healing;
        PlayerOne Pl1 = GameObject.Find("Player1").GetComponent<PlayerOne>();
        if(Pl1.Vita < 20)
        {
            Source.Play();
            Vita--;
            Pl1.Vita += 4;
        }
    }
}
