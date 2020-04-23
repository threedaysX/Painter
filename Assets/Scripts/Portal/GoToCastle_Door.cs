using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCastle_Door : MonoBehaviour {

    private PlayerControll PC;
    private FadeOut FO;

	// Use this for initialization
	void Start () {
        PC = FindObjectOfType<PlayerControll>();
        FO = FindObjectOfType<FadeOut>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PC.myRGB.velocity = new Vector2(0, 0);
            FO.ReadyToGoDoor = true;
        }

    }
}
