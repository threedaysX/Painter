using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour {

    public bool ReadyToGoDraw;
    public bool ReadyToGoWater;
    public bool ReadyToGoKing;
    public bool ReadyToGoDoor;

	// Use this for initialization
	void Start () {
        ReadyToGoDraw = false;
        ReadyToGoWater = false;
        ReadyToGoKing = false;
        ReadyToGoDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ReadyToGoDraw)
        {
            GetComponent<Animation>().Play("FadeOut畫廊");
        }
        else if(ReadyToGoWater)
        {
            GetComponent<Animation>().Play("FadeOut水池");
        }
        else if(ReadyToGoKing)
        {
            GetComponent<Animation>().Play("FadeOut王宮");
        }
        else if(ReadyToGoDoor)
        {
            GetComponent<Animation>().Play("FadeOut城門");
        }
	}

    public void FadeOutDrawWolf()
    {
        SceneManager.LoadScene("王宮");
    }

    public void FadeOutWater()
    {
        SceneManager.LoadScene("水池");
    }

    public void FadeOutKing()
    {
        SceneManager.LoadScene("王宮");
    }

    public void FadeOutDoor()
    {
        SceneManager.LoadScene("城門");
    }
}
