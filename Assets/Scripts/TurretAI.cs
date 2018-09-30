using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {

	//Animator anim;
	bool onCollision = false;
	public bool facingRight = false;

	public float bulletTimer;
	public float bulletSpeed = 100;
	public float shootInterval;
	public float CaricaSpeed = 3f;
	public float CaricaTimer = 1f;
	public float valoreCarica = 0f;
	public Vector3 originalPosition;

	float nextTimeToSearch;

	[SerializeField]
	GameObject Bullet;

	[SerializeField]
	Transform ShootPoint;

	Transform target;

	GameObject bulletClone;
	Rigidbody2D rbody;

	bool Stop = false;

	// Use this for initialization
	void Start () {
		//anim = gameObject.GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag("Fascio").GetComponent<Transform> ();
		rbody = this.gameObject.GetComponent<Rigidbody2D> ();
		originalPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool ("OnCollision", onCollision);
		//anim.SetBool ("FacingRight", facingRight);
		if(Stop && transform.position.y<originalPosition.y){
			Vector2 dir = originalPosition - transform.position;
			rbody.velocity = dir*CaricaSpeed;
		}
		if (onCollision && target) {
			if (target.position.x > transform.position.x) {
				facingRight = true;
			} else {
				facingRight = false;
			}
		} else if (!target) {
			FindTarget ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Fascio") {
			valoreCarica = ((target.transform.position.x + transform.position.x) / 2);
			Debug.Log ("Entrato in collisione");
			onCollision = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag != "Fascio") {
			Debug.Log ("Uscito dalla collisione");
			//ReturnBack ();
			rbody.velocity = new Vector2(0,0);
			CaricaTimer = 1f;
			ReturnBack ();
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Fascio") {
			onCollision = true;
			if (target.position.x < valoreCarica)
				Shoot (facingRight);
			else
				Carica ();
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.collider.name != "Fascio" && col.collider.tag != "Player") {
			Stop = true;
		}
	}

	public void Shoot(bool _facingRight){
		bulletTimer -= Time.deltaTime;
		if (bulletTimer <= 0) {
			Vector2 direction = (target.transform.position) - transform.position;
			direction.Normalize ();
			if (!facingRight) {
				bulletClone = Instantiate (Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			}
			else{
				bulletClone = Instantiate (Bullet, ShootPoint.transform.position, ShootPoint.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			}
			bulletTimer = shootInterval;
		}
	}

	public void Carica(){
		CaricaTimer -= Time.deltaTime;
		if (CaricaTimer <= 0) {
			Debug.Log ("Ti sto caricando");
			Vector2 direction = (target.transform.position) - transform.position;
			rbody.velocity = direction * CaricaSpeed;
		}
	}

	void FindTarget(){
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult=GameObject.Find("Fascio");
			if (searchResult != null)
				target = searchResult.GetComponent<Transform> ();
			nextTimeToSearch = Time.time + 0.5f;
		}
	}

	void ReturnBack(){
		float posxAttuale = transform.position.x;
		float posxOriginale = originalPosition.x;
		float posyAttuale = transform.position.y;
		float posyOriginale = transform.position.y;
		if (posxAttuale != posxOriginale && posyAttuale != posyOriginale) {
			Vector2 dir = originalPosition - transform.position ;
			rbody.velocity = dir*CaricaSpeed;
		}
	}
}
