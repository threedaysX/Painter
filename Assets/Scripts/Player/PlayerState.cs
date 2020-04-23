using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
	public static bool black = false;
	public static bool blue = false;
	public static bool gray = false;
	public static bool red = false;
	public static bool pink = false;
	public static bool yellow = false;

	public GameObject Empty_black;
	public GameObject fill_black;
	public GameObject Empty_blue;
	public GameObject fill_blue;
	public GameObject Empty_gray;
	public GameObject fill_gray;
	public GameObject Empty_red;
	public GameObject fill_red;
	public GameObject Empty_pink;
	public GameObject fill_pink;
	public GameObject Empty_yellow;
	public GameObject fill_yellow;

    private static bool black_disappear;
    private static bool blue_disappear;
    private static bool gray_disappear;
    private static bool red_disappear;
    private static bool pink_disappear;
    private static bool yellow_disappear;

    public static bool change_yet = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Stage_level.stage_is_on) /*進入關卡，顯示罐子*/
		{
            if(!change_yet)
            {
                if (black)
                {
                    Empty_black.SetActive(false);
                    fill_black.SetActive(true);
                }
                else
                {
                    Empty_black.SetActive(true);
                    fill_black.SetActive(false);
                }
                if (blue)
                {
                    Empty_blue.SetActive(false);
                    fill_blue.SetActive(true);
                }
                else
                {
                    Empty_blue.SetActive(true);
                    fill_blue.SetActive(false);
                }
                if (gray)
                {
                    Empty_gray.SetActive(false);
                    fill_gray.SetActive(true);
                }
                else
                {
                    Empty_gray.SetActive(true);
                    fill_gray.SetActive(false);
                }
                if (red)
                {
                    Empty_red.SetActive(false);
                    fill_red.SetActive(true);
                }
                else
                {
                    Empty_red.SetActive(true);
                    fill_red.SetActive(false);
                }
                if (pink)
                {
                    Empty_pink.SetActive(false);
                    fill_pink.SetActive(true);
                }
                else
                {
                    Empty_pink.SetActive(true);
                    fill_pink.SetActive(false);
                }
                if (yellow)
                {
                    Empty_yellow.SetActive(false);
                    fill_yellow.SetActive(true);
                }
                else
                {
                    Empty_yellow.SetActive(true);
                    fill_yellow.SetActive(false);
                }

                change_yet = true;
            }			
		} 
		else /*離開關卡，所有罐子不顯示*/
		{
            if(!change_yet)
            {
                Empty_black.SetActive(false);
                fill_black.SetActive(false);

                Empty_blue.SetActive(false);
                fill_blue.SetActive(false);

                Empty_gray.SetActive(false);
                fill_gray.SetActive(false);

                Empty_red.SetActive(false);
                fill_red.SetActive(false);

                Empty_pink.SetActive(false);
                fill_pink.SetActive(false);

                Empty_yellow.SetActive(false);
                fill_yellow.SetActive(false);

                /*離開關卡，所有罐子重置*/
                black = false;
                blue = false;
                gray = false;
                red = false;
                pink = false;
                yellow = false;

                change_yet = true; //設為true，表示已經變動過了，不需要在重複執行。
            }			 
		}
	}

    public static bool Black_disappear
    {
        get
        {
            return black_disappear;
        }

        set
        {
            black_disappear = value;
        }
    }

    public static bool Blue_disappear
    {
        get
        {
            return blue_disappear;
        }

        set
        {
            blue_disappear = value;
        }
    }

    public static bool Gray_disappear
    {
        get
        {
            return gray_disappear;
        }

        set
        {
            gray_disappear = value;
        }
    }
    public static bool Red_disappear
    {
        get
        {
            return red_disappear;
        }

        set
        {
            red_disappear = value;
        }
    }
    public static bool Pink_disappear
    {
        get
        {
            return pink_disappear;
        }

        set
        {
            pink_disappear = value;
        }
    }
    public static bool Yellow_disappear
    {
        get
        {
            return yellow_disappear;
        }

        set
        {
            yellow_disappear = value;
        }
    }
}
