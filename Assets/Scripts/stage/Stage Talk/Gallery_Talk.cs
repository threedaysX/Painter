using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery_Talk : MonoBehaviour {

    private PlayerControll Player;
    private FadeOut FO;
    public GameObject TalkBlock;
    public Text Text;
    public int num;
    public bool StartTalk;

    public bool PlayerClickDraw;

    // Use this for initialization
    void Start () {
        Player = FindObjectOfType<PlayerControll>();
        FO = FindObjectOfType<FadeOut>();
        StartTalk = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(StartTalk)
        {
            TalkBlock.SetActive(true);
            PlayerControll.canMove = false;

            if (Input.GetMouseButtonDown(0))
                num++;

            if (num == 0)
                Text.text = "少女直直看著這幅畫久久不動";
            else if (num == 1)
                Text.text = "「（不過，那可真是個特別的故事呢...）」";
            else if (num == 2)
                Text.text = "她慢慢的走到畫的前方";
            else if (num == 3)
                Text.text = "「還記得每次畫畫的時候，從開始到結束，就像旅行。」";
            else if (num == 4)
                Text.text = "「只有在那段時間，每個東西都有了生命一樣。」";
            else if (num == 5)
                Text.text = "「只屬於我的時間。」";
            else if (num == 6)
                Text.text = "畫師走到畫的旁邊後，輕輕摸了一下畫";
            else if (num == 7)
                Text.text = "突然，她的手穿過了畫，被吸了進去，周遭化為一片漆黑";
            else if (num == 8)
            {
                PlayerControll.atPoint = 1;
                FO.ReadyToGoDraw = true;
            }                
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                Player.myRGB.velocity = new Vector2(0, 0);
                PlayerClickDraw = true;
                Debug.Log("開始對話");
                StartTalk = true;
            }
        }

    }


}
