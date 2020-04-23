using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Control : MonoBehaviour {

    private bool need_black;
    private bool need_blue;
    private bool need_gray;
    private bool need_red;
    private bool need_pink;
    private bool need_yellow;

    public static bool finish_key = false;  //給任何程式可取用的，若所有顏色收集跟其餘任務完成，則把此KEY設為true;
    
    // Use this for initialization
    void Start () {
        
    }

	// Update is called once per frame
	void Update () {
        if(Stage_level.stage_is_on)
        {
            if (Stage_level.stage == 1)   ///判斷第幾關
            {                             
                if (need_black && need_blue && need_gray && need_pink && finish_key)  //完成所有需求顏色，並拿到KEY後觸發。
                {                    
                    PlayerState.Pink_disappear = true; //第一關結束，玩家再也不能使用粉紅色                   

                    need_black = false;
                    need_blue = false;
                    need_gray = false;
                    need_pink = false;
                    
                    Stage_level.instance.stage_end(); //if成立，關卡結束
                }
                else
                {
                    if(!need_black)
                    {
                        if (NPC_Draw.black)  ///NPC需求顏色。
                        {
                            need_black = true;                         
                        }
                    }        
                    if(!need_blue)
                    {
                        if (NPC_Draw.blue)
                        {
                            need_blue = true;
                        }
                    }                   
                    if(!need_gray)
                    {
                        if (NPC_Draw.gray)
                        {
                            need_gray = true;
                        }
                    }
                    if(!need_pink)
                    {
                        if (NPC_Draw.pink)
                        {
                            need_pink = true;
                        }
                    }
                }
            }
            else if (Stage_level.stage == 2)
            {

            }
            else if (Stage_level.stage == 3)
            {

            }
            else if (Stage_level.stage == 4)
            {

            }
            else if (Stage_level.stage == 5)
            {

            }
            else
            {

            }
        }
        else
        {

        }
    }
}
