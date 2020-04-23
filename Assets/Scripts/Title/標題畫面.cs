using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 標題畫面 : MonoBehaviour {

    public string StartScene;    //按Start要去的場景

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("王宮第一次對話", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        GetComponent<Animation>().Play("FadeOut");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartAnimOver()
    {
        Application.LoadLevel(StartScene);
    }



}
