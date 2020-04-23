using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_level : MonoBehaviour {

    public static bool stage_is_on = false;
    public static int stage = 0;

    public static Stage_level instance;


	// Use this for initialization
	void Start () {
		
	} 

    // Update is called once per frame
    void Update () {
        instance = this;
	}

    public void stage_start()
    {
        stage_is_on = true;
        NPC_Draw.read_mindSound_yet = false;
        PlayerState.change_yet = false;
        Player_bottle_disappear.change_yet = false;

        if (stage == 0)
        {
            stage = 1;
        }
        else if (stage == 1)
        {
            stage = 2;
        }
        else if (stage == 2)
        {
            stage = 3;
        }
        else if (stage == 3)
        {
            stage = 4;
        }
        else if (stage == 5)
        {
            stage = 5;
        }
        else 
        {
            Debug.Log("Wrong Scripts stage_start");
        }
    }

    public void stage_end()
    {
        stage_is_on = false;
        PlayerState.change_yet = false;
        Player_bottle_disappear.change_yet = false;
    }
}
