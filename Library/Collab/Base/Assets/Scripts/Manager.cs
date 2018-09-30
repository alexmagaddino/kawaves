using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject Player;
    public int Check;
    public Transform[] CheckPoints;
    public float timer, count;
    bool Separato;
    public int ScoreP1;
    public int ScoreP2;

    // Update is called once per frame
    void Start()
    {
        Separato = false;
        Check = 0;
        timer = count;
        ScoreP1 = 0;
        ScoreP2 = 0;
    }

    void Update()
    {
		if (Input.GetKeyDown (KeyCode.R)) {
			Destroy(GameObject.Find("PLAYER"));
			Destroy(GameObject.Find("PLAYER(Clone)"));
		}
		Spawn ();
        if( (GameObject.Find("Fascio").transform.localScale.x > 0.14f) || (GameObject.Find("Fascio").transform.localScale.x < -0.14f))
        {
            GameObject.Find("Fascio").GetComponent<SpriteRenderer>().enabled = false;
            Separato = true;
        }
        if (Separato)
        {
            if ((GameObject.Find("Fascio").transform.localScale.x > 0.07) || (GameObject.Find("Fascio").transform.localScale.x < -0.07f))
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    Destroy(GameObject.Find("PLAYER"));
                    Destroy(GameObject.Find("PLAYER(Clone)"));
                    timer = count;
                }
            }
            else if( (GameObject.Find("Fascio").transform.localScale.x < 0.07f) || (GameObject.Find("Fascio").transform.localScale.x < -0.07f))
            {
                Separato = false;
                GameObject.Find("Fascio").GetComponent<SpriteRenderer>().enabled = true;
                timer = count;
            }
        }
    }
    public void CheckPoint(int ID)
    {
        Check = ID;
    }

	void Spawn()
	{
		if (!GameObject.Find ("PLAYER")) {
			if ((!GameObject.Find ("PLAYER(Clone)"))) {
				Instantiate (Player, CheckPoints [Check].position, Quaternion.identity);
			}
		}
	}

    public void incScoreP1(int Quantity) {
        ScoreP1 += Quantity;
    }

    public void incScoreP2(int Quantity)
    {
        ScoreP2 += Quantity;
    }

    public int getScoreP1() {
        return ScoreP1;
    }

    public int getScoreP2()
    {
        return ScoreP2;
    }
}
