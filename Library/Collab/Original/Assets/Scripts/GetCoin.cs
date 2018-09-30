using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {
    public bool type500;
    private int CoinScore;
    public AudioClip Clip_coin, Clip_bigCoin;
    public AudioSource Source;
    public Sprite Moneta5;

    // Use this for initialization
    void Start () {
        if (!type500)
        {
            CoinScore = 100;
            Source.clip = Clip_coin;
        }

        else {
            CoinScore = 500;
            Source.clip = Clip_bigCoin;
            GetComponent<SpriteRenderer>().sprite = Moneta5;
        }
            
	}
	
	// Update is called once per frame
	void Update () {
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        Source.Play();
        if (col.gameObject.name == "Player1")
            GameObject.Find("Main Camera").GetComponent<Manager>().incScoreP1(CoinScore);

        if (col.gameObject.name == "Player2")
            GameObject.Find("Main Camera").GetComponent<Manager>().incScoreP2(CoinScore);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
