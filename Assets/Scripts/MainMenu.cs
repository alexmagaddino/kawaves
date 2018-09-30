using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject[] Scene, tasti;
    public Sprite[] Storiboarda;
    public Image StoriaPan;
	string MenuSect;
	public int KoJ, A;


	// Use this for initialization
	void Start () {
		KoJ = PlayerPrefs.GetInt ("KoJ");
	}
	
	// Update is called once per frame
	void Update () {
		switch (MenuSect) {
		case "Main":

			break;
		case "Setting":
			if (Input.GetKeyDown(KeyCode.Escape))
				Back ();
			break;

		case "Storia":
			break;
		}
	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void Play()
	{
		Application.LoadLevel (1);
	}

	public void Settings()
	{
		switch (KoJ) {
		case 0:
			tasti [0].GetComponent<Image> ().color = Color.red;
			tasti [1].GetComponent<Image> ().color = Color.white;
				break;
			case 1:
			tasti [1].GetComponent<Image> ().color = Color.red;
			tasti [0].GetComponent<Image> ().color = Color.white;
				break;
		}
		MenuSect = "Setting";
		Scene [0].SetActive (false);
		Scene [1].SetActive (true);
		Scene [2].SetActive (false);
	}

	public void Back()
	{
		Scene [0].SetActive (true);
		Scene [1].SetActive (false);
		Scene [2].SetActive (false);
		Save ();
		MenuSect = "Main";
	}

	void Save()
	{
		PlayerPrefs.SetInt ("KoJ", KoJ);
		PlayerPrefs.Save();
	}

	public void Keyboard()
	{
		tasti [0].GetComponent<Image> ().color = Color.red;
		tasti [1].GetComponent<Image> ().color = Color.white;
		KoJ  = 0;
	}

	public void Joystick()
	{
		tasti [1].GetComponent<Image> ().color = Color.red;
		tasti [0].GetComponent<Image> ().color = Color.white;
		KoJ = 1;
	}

	public void History()
	{
        A = 0;
        StoriaPan.GetComponent<Image>().sprite = Storiboarda[0];
        MenuSect = "Storia";
        Scene[0].SetActive(false);
        Scene[1].SetActive(false);
        Scene[2].SetActive(true);
    }

    public void Storia()
    {
        A++;
        StoriaPan.GetComponent<Image>().sprite = Storiboarda[1];
        if(A > 1)
        {
            Back();
        }
    }
}