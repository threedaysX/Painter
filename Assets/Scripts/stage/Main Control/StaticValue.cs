using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValue  {

    public static int from = 0;
    public static int L1Ktalk=0; //第一關騎士心聲
    public static int HaveReadWaterTalk = 0; //王宮走去水池 看到騎士跟公主在講話 講完後 HaveReadWaterTalk = 1
    public static int HaveReadKingTalk = 0; //畫廊剛傳送去王宮 看到國王在講話 講完後 HaveReadKingTalk = 1
    public static bool StartTalk = false;
     
}


//第一關至最後對話結束，後關卡結束，HaveReadWaterTalk值 = 6 (下次從6開始)。
//HaveReadKingTalk值 = 3 (下次從3開始)。