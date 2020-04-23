using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFocus : MonoBehaviour {
    //程式碼為執行canvas的fadein動畫

    public static bool need_Focus = false;
    private bool need_check = false; //檢查是否執行過

	// Use this for initialization
	void Start () {
        need_check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(need_Focus && !need_check)
        {
            Debug.Log("Focus");            
            //FadeIn();
            need_check = true;
        }
	}

    public void FadeIn()
    {
        //GetComponent<Animation>().Play("Fade_effect");
        
    }
}
