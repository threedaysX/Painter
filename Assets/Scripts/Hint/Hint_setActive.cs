using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_setActive : MonoBehaviour {

    public static bool OpenHint = false;
    public static bool check = false;
    public GameObject Need_OpenHint;

	// Use this for initialization
	void Start () {
        if(OpenHint)
        {
            OpenHint = false;
        }       
	}
	
	// Update is called once per frame
	void Update () {
		if(OpenHint && !check)
        {
            PlayerControll.canMove = false;
            PlayerControll.canDraw = false;
            NPC_Draw.canDraw_NPC = false;
            第一關騎士心聲.canClick = false;
            StaticValue.StartTalk = false;

            Hint_content.StartHint = true;
            Need_OpenHint.SetActive(true);
            check = true;
            Debug.Log("ONCE！");
        }
	}
}
