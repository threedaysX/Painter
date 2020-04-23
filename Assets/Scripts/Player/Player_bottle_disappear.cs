using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_bottle_disappear : MonoBehaviour {

    public GameObject black_crack;
    public GameObject blue_crack;
    public GameObject gray_crack;
    public GameObject red_crack;
    public GameObject pink_crack;
    public GameObject yellow_crack;

    public static bool change_yet = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Stage_level.stage_is_on)
        {
            if(!change_yet)
            {
                if (PlayerState.Black_disappear)
                {
                    black_crack.SetActive(true);
                }
                else
                {
                    black_crack.SetActive(false);
                }

                if (PlayerState.Blue_disappear)
                {
                    blue_crack.SetActive(true);
                }
                else
                {
                    blue_crack.SetActive(false);
                }

                if (PlayerState.Gray_disappear)
                {
                    gray_crack.SetActive(true);
                }
                else
                {
                    gray_crack.SetActive(false);
                }

                if (PlayerState.Red_disappear)
                {
                    red_crack.SetActive(true);
                }
                else
                {
                    red_crack.SetActive(false);
                }

                if (PlayerState.Pink_disappear)
                {
                    pink_crack.SetActive(true);
                }
                else
                {
                    pink_crack.SetActive(false);
                }

                if (PlayerState.Yellow_disappear)
                {
                    yellow_crack.SetActive(true);
                }
                else
                {
                    yellow_crack.SetActive(false);
                }

                change_yet = true;
            }            
        }
		else
        {
            if(!change_yet)
            {
                black_crack.SetActive(false);
                blue_crack.SetActive(false);
                gray_crack.SetActive(false);
                red_crack.SetActive(false);
                pink_crack.SetActive(false);
                yellow_crack.SetActive(false);

                change_yet = true;
            }            
        }
    }
}
