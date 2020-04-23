using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pool_Talk : MonoBehaviour
{

    private CameraController Camera;
    public GameObject TalkBlock;
    public Text Text;
    public Text Text_name;
    public int num;

    // Use this for initialization
    void Start()
    {
        Camera = FindObjectOfType<CameraController>();
        if(!Stage_level.stage_is_on)   //關卡開始後，每次切場景就不會隨時都StartTalk(可對話狀態)，需要的時候再各自調整。
        {
            StaticValue.StartTalk = true;
        }       
        TalkBlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {       
        if(!Stage_level.stage_is_on)     //關卡尚未開始，所有在水池的對話
        {
            if (StaticValue.HaveReadWaterTalk == 0)
            {
                if (StaticValue.StartTalk)
                {
                    TalkBlock.SetActive(true);
                    PlayerControll.canMove = false;
                    PlayerControll.canDraw = false;
                    NPC_Draw.canDraw_NPC = false;
                    第一關騎士心聲.canClick = false;

                    if (Input.GetMouseButtonDown(0))
                        num++;

                    if (num == 0)
                        Text.text = "畫師跟著騎士到了戶外，發現那裏有位蒙面的女性";
                    else if (num == 1)
                        Text.text = "依照她身上的禮服來看，看來也是來參加宴會的客人";
                    else if (num == 2)
                    {
                        Text_name.text = " 畫師 ";
                        Text.text = "「（不過既然來參加宴會，怎麼又會一個人在外面呢？）」";
                    }
                    else if (num == 3)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「美麗的小姐，你不去參加宴會嗎？」";
                    }                       
                    else if (num == 4)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「我都把臉遮住了，你卻還說我美麗？」";
                    }                       
                    else if (num == 5)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「至少你很特別。」";
                    }                       
                    else if (num == 6)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「特別有時候不代表珍貴，話說回來，應該還不到散場的時候吧。」";
                    }                    
                    else if (num == 7)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「是還沒到，但我有些厭倦了，於是出來透個氣。」";
                    }                    
                    else if (num == 8)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「一定是那些話很多的貴族女生吧。」";
                    }                   
                    else if (num == 9)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「我可沒有這麼說。」";
                    }                  
                    else if (num == 10)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「不然還會有其他原因嗎？不過阿，這也不能怪他們，貴族的社會就是如此，沒有任何一點自由。」";
                    }                   
                    else if (num == 11)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「是嗎?」";
                    }
                    
                    else if (num == 12)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「就是這樣。」";
                    }
                    
                    else if (num == 13)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「那妳自己呢?」";
                    }
                   
                    else if (num == 14)
                    {
                        Text_name.text = " 女人 ";
                        Text.text = "「這不重要，倒是你別讓裡面的淑女等太久，再會。」";
                    }                  
                    else if (num == 15)
                    {
                        Text_name.text = " 騎士 ";
                        Text.text = "「恩...」";
                    }                   
                    else if (num == 16)
                    {
                        Text.text = "女人頭也不回的轉身離開，留下騎士一人。";
                        Princess.RunAway = true; ;//公主離開
                    }
                    else if (num == 17)
                        Text.text = "騎士就僅僅只是站在那邊，靜靜地看著公主遠去。";
                    else if (num == 18)
                    {
                        Text_name.text = " 畫師 ";
                        Text.text = "「他在...想什麼？」";
                    }                    
                    else if (num == 19)
                        Text.text = "畫師望向了騎士的側臉，那臉上露出的表情，是她曾經見過的";
                    else if (num == 20)
                        Text.text = "那是在陷入迷茫的時候會露出的，只有嘴巴笑著的表情";
                    else if (num == 21)
                    {
                        Camera.Shake = true;
                        Text_name.text = " 畫師 ";
                        Text.text = "「這是...地震！」";
                    }
                    
                    else if (num == 22)
                    {
                        Text.text = "「左邊天空上的是.....什麼？」";
                    }
                    else if (num == 23)
                    {                       
                        // if (!ToFocus.need_Focus)
                        // {
                        //     ToFocus.need_Focus = true;
                        // }
                        // StaticValue.StartTalk = false;
                    }
                    else if (num == 24)
                        Text.text = "已經穿梭到畫中世界的她，很快的意識到這不會是單純的地震";
                    else if (num == 25)
                        Text.text = "「他們都沒有感覺嗎？（回頭望向宴會裡面)......」";
                    else if (num == 26)
                        Text.text = "轉過頭後，熱鬧的會場瞬間沒了聲音";
                    else if (num == 27)
                    {
                        Text.text = "整個環境跟人們身上的顏色也漸漸消失了";
                        Camera.Shake = false;
                    }
                    else if (num == 28)
                        Text.text = "「哈哈.....還真的像奇幻故事一樣」";
                    else if (num == 29)
                        Text.text = "「.............」";
                    else if (num == 30)
                        Text.text = "但是有些地方的顏色並沒有消失";
                    else if (num == 31)
                        Text.text = "畫師握緊手中的畫筆，但是她並不確定能不能做到些什麼";
                    else if (num == 32)
                        Text.text = "「跟我當初修畫的時候感覺一模一樣。」";
                    else if (num == 33)
                        Text.text = "直覺向來很準的她覺得在這個畫中的世界，或許有辦法";
                    else if (num == 34)
                        Text.text = "「看來連在夢裡也都要工作了。」";
                    else if (num == 35)
                        Text.text = "「（開工吧！）」";
                    else if (num == 36)
                    {
                        StaticValue.HaveReadWaterTalk = 1;
                        TalkBlock.SetActive(false);
                        PlayerControll.canMove = true;
                        PlayerControll.canDraw = true;
                        第一關騎士心聲.canClick = true;

                        StaticValue.StartTalk = false;
                        Stage_level.instance.stage_start();

                        num = 0;

                        Hint_setActive.OpenHint = true;
                    }
                }
            }
        }
        else  //關卡開始，其他所有在水池的對話
        {
            if (Stage_level.stage == 1)
            {
                if (StaticValue.HaveReadWaterTalk == 1)
                {
                    if (StaticValue.StartTalk)
                    {
                        if(NPC_Draw.gray)   //第一關，當玩家成功對NPC上色，顏色<灰色>。
                        {
                            TalkBlock.SetActive(true);
                            PlayerControll.canMove = false;
                            PlayerControll.canDraw = false;
                            第一關騎士心聲.canClick = false;

                            if (Input.GetMouseButtonDown(0))
                                num++;

                            if (num == 0)
                            {
                                Text_name.text = " 畫師 ";
                                Text.text = "「在我那裡，總會充滿紛爭。」";
                            }                                
                            else if (num == 1)
                                Text.text = "「（所以我很羨慕你們。）」";
                            else if (num == 2)
                                Text.text = "「有天，如果每個人都能像主角一樣。」";
                            else if (num == 3)
                                Text.text = "「是不是就會有個好結局了呢。」";
                            else if (num == 4)
                            {
                                StaticValue.HaveReadWaterTalk = 2;
                                TalkBlock.SetActive(false);
                                PlayerControll.canMove = true;
                                PlayerControll.canDraw = true;
                                第一關騎士心聲.canClick = true;

                                StaticValue.StartTalk = false;
                                num = 0;
                            }                           
                        }
                    }
                }
                else if (StaticValue.HaveReadWaterTalk == 2)
                {
                    if(StaticValue.StartTalk)
                    {
                        if (NPC_Draw.black)
                        {
                            TalkBlock.SetActive(true);
                            PlayerControll.canMove = false;
                            PlayerControll.canDraw = false;
                            第一關騎士心聲.canClick = false;

                            if (Input.GetMouseButtonDown(0))
                                num++;

                            if (num == 0)
                            {
                                Text_name.text = " 畫師 ";
                                Text.text = "「畫家這種職業阿，是僅僅舉起畫筆就能有無限的可能。」";
                            }                           
                            else if (num == 1)
                                Text.text = "「我不知道怎麼使劍，也不知道怎麼戰鬥。」";
                            else if (num == 2)
                                Text.text = "「但是如果說是為了誰而行動。」";
                            else if (num == 3)
                                Text.text = "「我想，這就是同一種可能性吧。」";
                            else if (num == 4)
                                Text.text = "「（對吧）」";
                            else if (num == 5)
                            {
                                StaticValue.HaveReadWaterTalk = 3;
                                TalkBlock.SetActive(false);
                                PlayerControll.canMove = true;
                                PlayerControll.canDraw = true;
                                第一關騎士心聲.canClick = true;

                                StaticValue.StartTalk = false;
                                num = 0;
                            }
                        }
                    }
                }
                else if (StaticValue.HaveReadWaterTalk == 3)
                {
                    if(StaticValue.StartTalk)
                    {
                        if (NPC_Draw.blue)
                        {
                            TalkBlock.SetActive(true);
                            PlayerControll.canMove = false;
                            PlayerControll.canDraw = false;
                            第一關騎士心聲.canClick = false;

                            if (Input.GetMouseButtonDown(0))
                                num++;

                            if (num == 0)
                            {
                                Text_name.text = " 畫師 ";
                                Text.text = "「會感到傷心並沒有錯。」";
                            }                               
                            else if (num == 1)
                                Text.text = "「宴會熱鬧也沒有錯。」";
                            else if (num == 2)
                                Text.text = "「但是這並不代表你需要去改變什麼」";
                            else if (num == 2)
                                Text.text = "「（並不代表...你就是錯誤的）」";
                            else if (num == 3)
                                Text.text = "「至少我們還在努力尋找答案。」";
                            else if (num == 4)
                                Text.text = "「（對吧......）」";
                            else if (num == 5)
                            {
                                StaticValue.HaveReadWaterTalk = 4;
                                TalkBlock.SetActive(false);
                                PlayerControll.canMove = true;
                                PlayerControll.canDraw = true;
                                第一關騎士心聲.canClick = true;

                                StaticValue.StartTalk = false;
                                num = 0;
                            }
                        }
                    }
                }
                else if (StaticValue.HaveReadWaterTalk == 4)
                {
                    if(StaticValue.StartTalk)
                    {
                        if (NPC_Draw.pink)
                        {
                            TalkBlock.SetActive(true);
                            PlayerControll.canMove = false;
                            PlayerControll.canDraw = false;
                            第一關騎士心聲.canClick = false;

                            if (Input.GetMouseButtonDown(0))
                                num++;

                            if (num == 0)
                                Text.text = "「（從剛剛開始心裡就亂糟糟的）」 ";
                            else if (num == 1)
                                Text.text = "「（你也是不容易呢...）」 ";
                            else if (num == 2)
                                Text.text = "「（辛苦了。）」";
                            else if (num == 3)
                            {
                                StaticValue.HaveReadWaterTalk = 5;
                                TalkBlock.SetActive(false);
                                PlayerControll.canMove = true;
                                PlayerControll.canDraw = true;
                                第一關騎士心聲.canClick = true;

                                StaticValue.StartTalk = false;
                                num = 0;
                            }
                        }
                    }
                }
                else if(StaticValue.HaveReadWaterTalk == 5)
                {
                    TalkBlock.SetActive(true);
                    PlayerControll.canMove = false;
                    PlayerControll.canDraw = false;
                    第一關騎士心聲.canClick = false;

                    if (Input.GetMouseButtonDown(0))
                        num++;

                    if (num == 0)
                    {
                        Text_name.text = " 畫師 ";
                        Text.text = "「看來是都上好色了。」";
                    }
                    else if (num == 1)
                        Text.text = "「這樣應該就沒事了。」";
                    else if (num == 2)
                        Text.text = "「好久沒有這種感覺了，真累~」";
                    else if (num == 3)
                        Text.text = "「看過他的記憶後...有點擔心。」";
                    else if (num == 4)
                        Text.text = "「不過......」";
                    else if (num == 5)
                        Text.text = "「希望這個故事就跟我曾經所看過的故事一樣就好。」";
                    else if (num == 5)
                        Text.text = "「（總感覺有一種違和感。）」";
                    else if (num == 6)
                        Text.text = "在看過騎士的記憶之後，她的頭不斷的痛著";
                    else if (num == 7)
                        Text.text = "「我現在能做的就是幫你們補好顏色...」";
                    else if (num == 8)
                        Text.text = "「因為這是我的工作。」 ";
                    else if (num == 9)
                        Text.text = "「（因為我跟他們約好了。）」";                       
                    else if (num == 10)
                        Text.text = "「算了，先別想太多。」";
                    else if (num == 11)
                        Text.text = "畫師拍了拍臉，伸了一下懶腰";
                    else if (num == 12)
                        Text.text = "「接下來，還有剛剛的天空...！」";
                    else if (num == 13)
                        Text.text = "畫師一抬頭，就發現剛剛出現的裂縫在這段期間";
                    else if (num == 14)
                        Text.text = "...變成了比深淵還要混濁的奇怪顏色";
                    else if (num == 15)
                        Text.text = "紅色...藍色...粉白....藍紫...灰色....黃色....";
                    else if (num == 16)
                        Text.text = "裂縫的周圍，還環繞著粉白色的奇怪波紋。";
                    else if (num == 17)
                        Text.text = "似乎是要將什麼吸入一般。";
                    else if (num == 18)
                        Text.text = "「...要把它清除掉才行。」";
                    else if (num == 19)
                        Text.text = "「試著補上顏色看看吧。」";
                    else if (num == 20)
                        Text.text = "「（似乎是粉白色？）」";
                    else if (num == 21)
                    {
                        StaticValue.HaveReadWaterTalk = 6;          //第一關最後對話，值為6。
                        TalkBlock.SetActive(false);
                        PlayerControll.canMove = true;
                        PlayerControll.canDraw = true;
                        第一關騎士心聲.canClick = true;

                        StaticValue.StartTalk = false;
                        num = 0;
                    }
                }           
            }
        }
    }
}
