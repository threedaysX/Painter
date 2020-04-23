using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle_DoorToPalace : MonoBehaviour {

    public bool canClick;
    private FadeOut FO;

	// Use this for initialization
	void Start () {
        FO = FindObjectOfType<FadeOut>();
	}
	
	// Update is called once per frame
	void Update () {
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

    public void OnMouseDown()
    {
        if (canClick)
        {
            StaticValue.from = 1;
            FO.ReadyToGoKing = true;
        }
    }
}
