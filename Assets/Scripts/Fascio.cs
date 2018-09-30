using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fascio : MonoBehaviour {

    float x1, x2 , y1,y2,xm,ym;
    // Update is called once per frame
    void Update() {
        x1 = GameObject.Find("Player1").transform.position.x;
        y1 = GameObject.Find("Player1").transform.position.y;
        x2 = GameObject.Find("Player2").transform.position.x;
        y2 = GameObject.Find("Player2").transform.position.y;
        xm = (x1 + x2) / 2;
        ym = (y1 + y2) / 2;
        transform.Rotate(new Vector3(0, 0, Rotate() + 90));

        transform.localScale = new Vector3((xm - x1)/25 ,.1f, 1);
        if(Mathf.Abs(x2-x1) < 1)
        {
            transform.localScale = new Vector3((ym - y1)/25,.1f, 1);
        }
        transform.position =new Vector3( xm , ym) ;
        
	}

    float Rotate()
    {
        Vector3 targetDir = GameObject.Find("Player1").transform.position - gameObject.transform.position;
        Vector3 forward = transform.up;
        return Vector3.Angle(targetDir, forward);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == "Death")
        {
            Destroy(GameObject.Find("PLAYER"));
            Destroy(GameObject.Find("PLAYER(Clone)"));
        }
    }
}
