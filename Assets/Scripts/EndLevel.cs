using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour {

    public GameObject Panel;
    public Sprite Credits;
    public float count, timer;
    bool Cred;

    void Update()
    {
        if (Cred)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Application.LoadLevel("MainMenu");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        Panel.SetActive(true);
        Panel.GetComponent<Image>().sprite = Credits;
        Cred = true;   
    }
}
