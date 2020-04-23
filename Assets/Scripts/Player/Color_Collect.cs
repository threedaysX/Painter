using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Collect : MonoBehaviour {

    public static bool mouseIsUse;
    public static bool StartTurn = false;
    public static bool Drawing = false;
    public static bool Player_Is_nearby;

    public static Color_Collect CC;

    // Use this for initialization
    void Start () {
		CC = this;
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player_Is_nearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player_Is_nearby = false;
        }
    }

    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (PlayerControll.canDraw)
            {
                if (Player_Is_nearby)
                {
                    if (this.gameObject.tag != "crack")     //判斷玩家點擊的物件是不是裂縫，是的話要先確認有沒有收集到所有顏色並已經幫NPC補上對應顏色。
                    {
                        StartTurn = true;
                        mouseIsUse = true;
                        Drawing = true;
                        PlayerControll.TurnAni = 1;
                        PlayerControll.DrawAni = 1;
                        //轉身開始，停止移動，滑鼠放開才可以移動。
                        Invoke("to_fill_bottle", 2);
                    }
                    else
                    {
                        if (Stage_level.stage == 1)
                        {
                            if (NPC_Draw.black && NPC_Draw.blue && NPC_Draw.gray && NPC_Draw.pink)
                            {
                                StartTurn = true;
                                mouseIsUse = true;
                                Drawing = true;
                                PlayerControll.TurnAni = 1;
                                PlayerControll.DrawAni = 1;
                                //轉身開始，停止移動，滑鼠放開才可以移動。
                                Invoke("to_fill_bottle", 2);
                            }
                        }
                    }                    
                }
            }
        }                             
	}
	void OnMouseUp()
	{
		mouseIsUse = false;
        Drawing = false;
        StartTurn = false;
        PlayerControll.End = 1;
        PlayerControll.TurnAni = 0;
        PlayerControll.DrawAni = 0;
    }

	void to_fill_bottle() /*按住滑鼠兩秒後，對應顏色填入對應罐子*/
	{
		if (mouseIsUse)
		{
			if (this.gameObject.tag == "black") {
                if(PlayerState.Black_disappear) {
                    PlayerState.black = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.black = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。
                }				               
            }
			else if(this.gameObject.tag == "blue") {
                if (PlayerState.Blue_disappear)
                {
                    PlayerState.blue = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.blue = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。

                    if (Stage_level.stage_is_on)  //關卡1，王宮中藍綠色被收集後消失。
                    {
                        if (Stage_level.stage == 1)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }                
            }
			else if(this.gameObject.tag == "gray") {
                if (PlayerState.Gray_disappear) //如果該顏色消失了，那就不能用(false)，也不會觸發對話。
                {
                    PlayerState.gray = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.gray = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。
                }
            }
			else if(this.gameObject.tag == "red") {
                if (PlayerState.Red_disappear)
                {
                    PlayerState.red = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.red = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。
                }
            }
			else if(this.gameObject.tag == "pink") {
                if (PlayerState.Pink_disappear)
                {
                    PlayerState.pink = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.pink = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。
                }
            }
			else if(this.gameObject.tag == "yellow") {
                if (PlayerState.Yellow_disappear)
                {
                    PlayerState.yellow = false;
                    StaticValue.StartTalk = false;
                }
                else
                {
                    PlayerState.yellow = true;
                    StaticValue.StartTalk = true;
                    PlayerState.change_yet = false; //已經改變>>設成false，表示偵測到收集到新的顏色，所以要去改變罐子的狀態。
                }
            }           
            else if(this.gameObject.tag == "crack")
            {
                if(Stage_level.stage_is_on)
                {
                    if(Stage_level.stage == 1)
                    {
                        if(StaticValue.HaveReadWaterTalk == 6)      //第一關至最後對話結束，玩家會在水池，值為6
                        {
                            Story_Control.finish_key = true;
                        }
                    }
                }               
            }

            Drawing = false;
            StartTurn = false;
            PlayerControll.End = 1;
            PlayerControll.TurnAni = 0;
            PlayerControll.DrawAni = 0;
        }
	}
}
