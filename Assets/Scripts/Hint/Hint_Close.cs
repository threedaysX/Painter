using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint_Close : MonoBehaviour {

    public static bool CloseHint = false;

    private void Start()
    {
        CloseHint = false;
    }

    private void Update()
    {
        if(CloseHint)
        {
            Hint_setActive.OpenHint = false;
            Hint_setActive.check = false;

            PlayerControll.canMove = true;
            PlayerControll.canDraw = true;
            NPC_Draw.canDraw_NPC = true;
            第一關騎士心聲.canClick = true;


            GameObject.FindGameObjectWithTag("Hint").SetActive(false);
            if (GalleryFirstIn.Still_need_Talk)
            {
                StaticValue.StartTalk = true;
            }            

            Hint_content.StartHint = false;
            CloseHint = false;
        }
    }
}
