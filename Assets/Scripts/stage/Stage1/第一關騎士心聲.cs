using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 第一關騎士心聲 : MonoBehaviour {

    public GameObject MindSound;
    public static bool canClick;
    public bool StartPlay;
    private PlayerControll Player;

    public GameObject TalkBlock;
    public Text Text_name;
    public Text Text;
    public int num;
    public static bool close = false;

	public static float timer_f=0f;
	public int timer_i=0;

	public Text T1;	
	public Text T2;
	public Text T3; 
	public Text T4;
	public Text T5;
	public Text T6;
	public Text B1;
	public Text B2;
	public Text B3;
	public Text B4;
	public Text B5;
	public Text B6;
	public bool startTime;
	public Color32 grayC = new Color32 (208, 203, 200, 255);
	public Color32 blueC = new Color32(106, 176, 178,255);
	public Color32 purpleC = new Color32(30, 28, 65,255);
	public Color32 pinkC = new Color32(253, 196, 191,255);

    // Use this for initialization
    void Start () {
        Player = FindObjectOfType<PlayerControll>();
		B1.color = grayC;
		B2.color = blueC;
		B3.color = purpleC;
		B4.color = blueC;
		B5.color = grayC;
		B6.color = pinkC;
	}
	
	// Update is called once per frame
	void Update () {

        if(StaticValue.L1Ktalk == 1)
        if (StartPlay)
        {
            TalkBlock.SetActive(true);
            PlayerControll.canMove = false;
            PlayerControll.canDraw = false;
            NPC_Draw.canDraw_NPC = false;
            canClick = false;

            if (Input.GetMouseButtonDown(0))
                num++;

            if (num == 0)
            {
                Text_name.text = " 畫師 ";
                Text.text = "「這是.....他的記憶？」";
            }                
            else if (num == 1)
                Text.text = "騎士腦海中的想法一點一點地湧入畫師的腦海";
            else if (num == 1)
                Text.text = "「從沒體會過的感覺...這還真是...」";
            else if (num == 1)
                Text.text = "各種情緒混雜在心裡";
            else if (num == 2)
                Text.text = "「.......」";
            else if (num == 1)
                Text.text = "畫師似乎也明白了些什麼";
            else if (num == 3)
                Text.text = "「你啊，對第一次見面的人，可不能這樣......」";
            else if (num == 4)
                Text.text = "「（明明連自己的問題都無法解決....不舒服的感覺持續的浮現出來....）」";
            else if (num == 5)
                Text.text = "「（人心真是可怕）」";
            else if (num == 6)
                Text.text = "「（脆弱的時候總是會把他人投射成自己想像的....）」";
            else if (num == 7)
                Text.text = "「他的顏色又變淡了......？」";
            else if (num == 8)
                Text.text = "「哈哈......」";
            else if (num == 9)
                Text.text = "「（看向四周）這地方應該會有些能用的顏色吧。」";
            else if (num == 10)
                Text.text = "「大概知道要補上什麼了。」";
            else if (num == 11)
                Text.text = "「（幫他一下吧！）」";
            else if(num == 12)
            {
                TalkBlock.SetActive(false);
                PlayerControll.canMove = true;
                PlayerControll.canDraw = true;
                NPC_Draw.canDraw_NPC = true;
                canClick = true;

                StartPlay = false;
                StaticValue.L1Ktalk = 0;
                NPC_Draw.read_mindSound_yet = true;
                
                Hint_setActive.OpenHint = true;
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canClick = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canClick = false;
        }

    }

    static float nowVolume;

    public void CloseMind()
    {
        MindSound.SetActive(false);
        PlayerControll.canMove = true;
        StartPlay = true;
        if (!close)
        {
            StaticValue.L1Ktalk = 1;
            close = true;
        }
        GameObject.FindGameObjectWithTag("StageSound").GetComponent<VolumeModifying>().SetVolume(nowVolume); //音樂調回原本聲量
        NPC_Draw.canDraw_NPC = true;
    }

	IEnumerator ChangeTextColor()
	{
		yield return new WaitForSeconds (3);
		Debug.Log ("123");
		T1.color = grayC;
		T2.color = blueC;
		T3.color = purpleC;
		T4.color = blueC;
		T5.color = grayC;
		T6.color = pinkC;
	}

    public void Click()
    {
        if(canClick)
        {
            PlayerControll.canMove = false;
            MindSound.SetActive(true);            
            NPC_Draw.canDraw_NPC = false;
			StartCoroutine (ChangeTextColor());
        }
			
    }

    public void OnMouseDown()
    {
        if (canClick)
        {
			StartCoroutine (ChangeTextColor());
            Player.myRGB.velocity = new Vector2(0,0);
            PlayerControll.canMove = false;
            MindSound.SetActive(true);
            nowVolume = GameObject.FindGameObjectWithTag("StageSound").GetComponent<VolumeModifying>().volumn;
            if(nowVolume < 0.3f)
            {
                GameObject.FindGameObjectWithTag("StageSound").GetComponent<VolumeModifying>().SetVolume(nowVolume); //音樂調小聲
            }
            else
            {
                GameObject.FindGameObjectWithTag("StageSound").GetComponent<VolumeModifying>().SetVolume(0.3f); //音樂調小聲
            }                       
        }
    }
}
