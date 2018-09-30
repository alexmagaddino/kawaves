using UnityEngine;
using System.Collections;

public class Pipistrello : MonoBehaviour {

	//Animator anim;
	bool onCollision = false;
	public bool facingRight = false;

	public float bulletTimer;
	public float bulletSpeed = 100;
	public float shootInterval;

	float nextTimeToSearch;

	[SerializeField]
	GameObject Bullet;

	[SerializeField]
	Transform shootPointLeft;
	[SerializeField]
	Transform shootPointRight;

	Transform target;

	GameObject bulletClone;

	// Use this for initialization
	void Start () {
		//anim = gameObject.GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Fascio").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool ("OnCollision", onCollision);
		//anim.SetBool ("FacingRight", facingRight);

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
			Debug.Log ("Entrato in collisione");
			onCollision = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Debug.Log ("Uscito dalla collisione");
		onCollision = false;
		return;
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == "Fascio") {
			onCollision = true;
			Shoot (facingRight);
		}
	}

	public void Shoot(bool _facingRight){
		bulletTimer += Time.deltaTime;
		if (bulletTimer >= shootInterval) {
			Vector2 direction = (target.transform.position) - transform.position;
			direction.Normalize ();
			if (!facingRight) {
				bulletClone = Instantiate (Bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			}
			else{
				bulletClone = Instantiate (Bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			}
			bulletTimer = 0;
		}
	}

	void FindTarget(){
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult=GameObject.FindGameObjectWithTag ("Fascio");
			if (searchResult != null)
				target = searchResult.GetComponent<Transform> ();
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
		
}
