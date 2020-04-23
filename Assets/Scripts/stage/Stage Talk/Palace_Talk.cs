using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Palace_Talk : MonoBehaviour {

    public GameObject TalkBlock;
    public Text Text;
    public Text Text_name;
    private int num;

    // Use this for initialization
    void Start () {
        if (!Stage_level.stage_is_on)   //關卡開始，每次切場景就不會隨時都StartTalk(可對話狀態)，需要的時候再各自調整。
        {
            StaticValue.StartTalk = true;

        }
        TalkBlock.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(!Stage_level.stage_is_on)    //關卡尚未開始，所有在王宮的對話。
        {
            if (StaticValue.HaveReadKingTalk == 0)
            {
                if (StaticValue.StartTalk)
                {
                    TalkBlock.SetActive(true);

                    PlayerControll.canMove = false;
                    PlayerControll.canDraw = false;
                    NPC_Draw.canDraw_NPC = false;

                    if (Input.GetMouseButtonDown(0))
                        num++;

                    if (num == 0)
                        Text.text = "她進入了這幅畫，她意識到了這件事，\n一點也不驚恐的她倒是開始漫步起來享受身體恢復的舒暢感";
                    else if (num == 1)
                        Text.text = "「.....看來我想像力也挺不錯的。」";
                    else if (num == 2)
                        Text.text = "她看著眼前慢慢成形的畫面，自嘲了一句，接著發現自己身在一座裝飾輝煌的宮殿，像是在舉行宴會一般，非常熱鬧";
                    else if (num == 3)
                    {
                        Text_name.text = " 國王 ";
                        Text.text = "「這一杯，敬所有為國奮戰的勇士！」";
                    }                        
                    else if (num == 4)
                    {
                        Text_name.text = " 所有人 ";
                        Text.text = "「喔！！！！！！」";
                    }                       
                    else if (num == 5)
                    {
                        Text_name.text = " 國王 ";
                        Text.text = "「今天晚上，大家拋開所有煩惱，這場宴會，是屬於你們的慶功宴！」";
                    }                    
                    else if (num == 6)
                    {
                        Text_name.text = " 所有人 ";
                        Text.text = "「喔！！！！！！」";
                    }                   
                    else if (num == 7)
                    {
                        Text_name.text = " 畫師 ";
                        Text.text = "「真是熱鬧阿，是國王在犒賞剛回國的士兵們吧。」";
                    }                    
                    else if (num == 8)
                    {
                        Text_name.text = " 騎士A ";
                        Text.text = "「終於結束了，這場戰爭。」";
                    }                    
                    else if (num == 9)
                    {
                        Text_name.text = " 騎士B ";
                        Text.text = "「是阿，但我弟弟他.....」";
                    }                  
                    else if (num == 10)
                    {
                        Text_name.text = " 騎士A ";
                        Text.text = "「別說了，今晚是開心的慶功宴，就算只有現在，忘掉它吧。」";
                    }                  
                    else if (num == 11)
                    {
                        Text_name.text = " 騎士B ";
                        Text.text = "「也許你是對的....」";
                    }                    
                    else if (num == 12)
                    {
                        Text_name.text = " 畫師 ";
                        Text.text = "一旁聽著的畫師，多少能夠體會一些關於戰爭的後果";
                    }                   
                    else if (num == 13)
                        Text.text = "宴會持續熱鬧著";
                    else if (num == 14)
                        Text.text = "這些氣氛還是足以蓋過這些「小事」";
                    else if (num == 15)
                    {
                        Text.text = "然後畫師歪著頭站在兩位騎士的面前揮了揮手";
                    }
                    else if (num == 15)
                        Text.text = "「喂~」";
                    else if (num == 16)
                        Text.text = "「喂！」";
                    else if (num == 17)
                    {
                        Text.text = "一點反應也沒有...";
                    }
                    else if (num == 18)
                    {
                        Text.text = "才發現原來他們是真的看不到自己的，少女便露出了一個放鬆的笑容";
                    }
                    else if (num == 18)
                    {
                        Text.text = "畢竟她根本不是這時代該出現的人物";
                    }
                    else if (num == 19)
                    {
                        Text.text = "她悠閒的逛著這個會場，十分的滿足現在的身體";
                    }
                    else if (num == 20)
                    {
                        Text.text = "在此時，她向宴會的左方看去";
                    }
                    else if (num == 21)
                    {
                        Text.text = "發現有個騎士孤零零地推開了王宮的側門，走進了黑夜之中";
                    }
                    else if (num == 22)
                    {
                        Text.text = "「他不參加慶功宴嗎？」";
                    }
                    else if (num == 23)
                    {
                        Text.text = "畫師露出了好奇的眼神，走向了『左側』的大門";
                    }
                    else if (num == 24)
                    {
                        TalkBlock.SetActive(false);
                        PlayerControll.canMove = true;
                        PlayerControll.canDraw = true;
                        NPC_Draw.canDraw_NPC = true;

                        StaticValue.HaveReadKingTalk = 1;
                        StaticValue.StartTalk = false;
                        num = 0;
                    }
                }
            }
        }           
        else       //關卡開始，所有在王宮的對話
        {
           if(Stage_level.stage == 1)
            {
                if (StaticValue.HaveReadKingTalk == 1)
                {
                    StaticValue.StartTalk = true;   //關卡開始後，第一次進到王宮，發現王宮變成藍綠色，開始對話。
                    if (StaticValue.StartTalk)
                    {
                        TalkBlock.SetActive(true);
                        PlayerControll.canMove = false;
                        PlayerControll.canDraw = false;
                        NPC_Draw.canDraw_NPC = false;
                        Palace_blue.Palace_Color_blue = true; //此行為第一關出現藍色螢幕(true)

                        if (Input.GetMouseButtonDown(0))
                            num++;
                        if (num == 0)
                        {
                            Text_name.text = " 畫師 ";
                            Text.text = "「（怎麼會變成這種顏色...）」";
                        }
                        else if (num == 1)
                        {
                            Text.text = "淺藍色的迷霧籠罩在宴會之中";
                        }
                        else if (num == 2)
                        {
                            Text.text = "那些在會場中停止動作的人們，感覺就像是被這迷霧緊緊的束縛著";
                        }
                        else if (num == 3)
                        {
                            Text.text = "原本難過、傷心、倔強的氣息，毫無保留的充斥在這片迷霧之中";
                        }
                        else if (num == 4)
                        {
                            Text.text = "那是戰爭所留下的，是熱鬧的宴會也無法改變的事實";
                        }
                        else if (num == 5)
                        {
                            Text.text = "畫師直直地站在一旁，本能地察覺到必須要修補好這個問題";
                        }
                        else if (num == 6)
                        {
                            Text.text = "「（先把這裡的問題解決吧...）」";
                        }
                        else if(num == 7)
                        {
                            TalkBlock.SetActive(false);
                            PlayerControll.canMove = true;
                            PlayerControll.canDraw = true;
                            NPC_Draw.canDraw_NPC = true;

                            StaticValue.HaveReadKingTalk = 2;
                            StaticValue.StartTalk = false;
                            num = 0;
                        }
                    }
                }
                if(StaticValue.HaveReadKingTalk == 2)   //關卡開始後，玩家收集到藍綠色後，開始對話。
                {
                    if(StaticValue.StartTalk)
                    {
                        if(PlayerState.blue)
                        {
                            TalkBlock.SetActive(true);
                            PlayerControll.canMove = false;
                            PlayerControll.canDraw = false;
                            NPC_Draw.canDraw_NPC = false;                            

                            if (Input.GetMouseButtonDown(0))
                                num++;
                            if (num == 0)
                            {
                                Text.text = "畫師盯著那片淺藍色的迷霧，本能地舉起了她手中的畫筆";
                            }
                            else if (num == 1)
                            {
                                Palace_blue.Palace_Color_blue = false; //此行為第一關藍色螢幕被收集完畢後消失(false)
                                Text.text = "在她動了幾下後，原本存在宴會中的怪異氛圍就消失了。";
                            }
                            else if (num == 1)
                            {
                                Text.text = "她意識到她似乎能夠像以前一樣把畫修好";
                            }
                            else if (num == 1)
                            {
                                Text.text = "即便是在這個畫中世界也是如此";
                            }
                            else if (num == 1)
                            {
                                Text_name.text = " 畫師 ";
                                Text.text = "「（這樣應該就沒事了。）」";
                            }
                            else if (num == 2)
                            {
                                Text.text = "「（宴會本來就該熱鬧一點）」 ";
                            }
                            else if (num == 3)
                            {
                                TalkBlock.SetActive(false);
                                PlayerControll.canMove = true;
                                PlayerControll.canDraw = true;
                                NPC_Draw.canDraw_NPC = true;

                                StaticValue.HaveReadKingTalk = 3;
                                StaticValue.StartTalk = false;

                                num = 0;
                            }
                        }                       
                    }
                }
            }
        }
    }
}
