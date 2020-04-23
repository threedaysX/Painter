using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryFirstIn : MonoBehaviour
{

    private PlayerControll Player;
    private Gallery_Talk Fin;
    public GameObject TalkBlock;
    public Text Text;
    public int num = 0;

    public static bool Still_need_Talk = false;

    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<PlayerControll>();
        Fin = FindObjectOfType<Gallery_Talk>();
        StaticValue.StartTalk = true;       
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticValue.StartTalk)
        {
            TalkBlock.SetActive(true);
            PlayerControll.canMove = false;
            PlayerControll.canDraw = false;

            if(!Still_need_Talk)
            {
                Hint_setActive.OpenHint = true;
                Still_need_Talk = true;
                TalkBlock.SetActive(false);
            }            

            if (Input.GetMouseButtonDown(0))
                num++;
            
            if (num == 0)
            {               
                Text.text = "「這裡是…？我記得我躺在床上才是阿…」";
            }
            else if (num == 1)
                Text.text = "「身體突然變得好輕盈。」";
            else if (num == 2)
                Text.text = "  她看向自己的手，輕輕地揮了幾下";
            else if (num == 3)
                Text.text = "「這是....我小時候的身體...？」";
            else if (num == 4)
                Text.text = "「而且我的視力也恢復了...」";
            else if (num == 5)
                Text.text = "「這是在夢中...？」";
            else if (num == 6)
                Text.text = "畫師看向四周，才發現這個地方是畫廊";
            else if (num == 7)
                Text.text = "牆上有著斑駁的痕跡，灰黃色的斑紋與茫茫的霧氣充斥在這個環境中";
            else if (num == 8)
                Text.text = "不難看出這裡是已經有點年代的畫廊";
            else if (num == 9)
            {
                Text.text = "而她轉頭往右方看了一下發現";                
            }
            else if (num == 10)
            {
                if (!ToFocus.need_Focus)
                {
                    ToFocus.need_Focus = true;
                }               
                StaticValue.StartTalk = false;
            }
            else if (num == 11)
            {                
                Text.text = "「啊！」";
            }
            else if (num == 12)
                Text.text = "「那幅畫！真懷念阿，它可是我小時候最喜歡的畫呢。」";
            else if (num == 13)
                Text.text = "「...顏色是不是有點太淡了。」";
            else if (num == 14)
                Text.text = "「還是是角度的問題？」";
            else if (num == 15)
                Text.text = "「(先走近看看吧)」";
            else if (num == 16)
            {
                StaticValue.StartTalk = false;
                TalkBlock.SetActive(false);
                PlayerControll.canMove = true;
                num = 0;
            }
        }
    }
}
