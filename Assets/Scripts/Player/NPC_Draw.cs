using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Draw : MonoBehaviour {

    public static bool black = false;
    public static bool blue = false;
    public static bool gray = false;
    public static bool red = false;
    public static bool pink = false;
    public static bool yellow = false;

    public static bool canDraw_NPC = false;
    public static bool read_mindSound_yet = false;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canDraw_NPC = true;
            Debug.Log("YP");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canDraw_NPC = false;
        }
    }

    private void OnMouseDown()
    {
        if(read_mindSound_yet)
        {
            if (canDraw_NPC)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (PlayerState.black)
                    {
                        black = true;
                        PlayerState.black = false;
                        StaticValue.StartTalk = true;
                        
                        Debug.Log("black");
                    }
                    if (PlayerState.blue)
                    {
                        blue = true;
                        PlayerState.blue = false;
                        StaticValue.StartTalk = true;

                        Debug.Log("blue");
                    }
                    if (PlayerState.gray)
                    {
                        gray = true;
                        PlayerState.gray = false;
                        StaticValue.StartTalk = true;

                        Debug.Log("gray");
                    }
                    if (PlayerState.red)
                    {
                        red = true;
                        PlayerState.red = false;
                        StaticValue.StartTalk = true;

                        Debug.Log("red");
                    }
                    if (PlayerState.pink)
                    {
                        pink = true;
                        PlayerState.pink = false;
                        StaticValue.StartTalk = true;

                        Debug.Log("pink");
                    }
                    if (PlayerState.yellow)
                    {
                        yellow = true;
                        PlayerState.yellow = false;
                        StaticValue.StartTalk = true;

                        Debug.Log("yellow");
                    }
                }
            }
        }        
    }
}
