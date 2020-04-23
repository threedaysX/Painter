using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint_content : MonoBehaviour {

    public Text text;
    public static bool StartHint = false;
    private int Hint_order = 0;
    private int num = 0;

	// Use this for initialization
	void Start () {
        StartHint = false;      
	}
	
	// Update is called once per frame
	void Update () {

        if (Hint_order == 0)
        {
            if (StartHint)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    num++;
                }

                if (num == 0)
                {
                    text.text = "滑動滑鼠以控制移動，停在螢幕中間以停止移動";
                }
                else if (num == 1)
                {
                    text.text = "點擊左鍵進行對話或與物品、人物互動";
                }
                else if (num == 2)
                {
                    text.text = "ESC可以開啟選單";
                }
                else if (num == 3)
                {
                    Hint_order = 1;
                    num = 0;
                    Hint_Close.CloseHint = true;
                    StartHint = false;
                }
            }
        }
        else if (Hint_order == 1)
        {
            if (StartHint)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    num++;
                }

                if (num == 0)
                {
                    text.text = "點擊左鍵可以去理解NPC的心聲，右鍵按住可以收集顏色";
                }
                else if (num == 1)
                {
                    Hint_order = 2;
                    num = 0;
                    Hint_Close.CloseHint = true;
                    StartHint = false;
                }
            }                
        }
        else if (Hint_order == 2)
        {
            if(StartHint)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    num++;
                }

                if (num == 0)
                {
                    text.text = "NPC的心聲中，被塗掉的地方就是畫中故事的缺陷";
                }
                else if (num == 1)
                {
                    text.text = "試著去收集地圖上與缺陷相同的顏色！";
                }
                else if (num == 2)
                {
                    text.text = "收集到之後，對著NPC按住右鍵一一的上色吧！";
                }
                else if (num == 3)
                {
                    Hint_order = 3;
                    num = 0;
                    Hint_Close.CloseHint = true;
                    StartHint = false;
                }
            }           
        }

    }
}
