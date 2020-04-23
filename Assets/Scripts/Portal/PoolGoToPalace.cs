using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGoToPalace : MonoBehaviour {

    private FadeOut FO;
    private PlayerControll PC;

    // Use this for initialization
    void Start () {

        FO = FindObjectOfType<FadeOut>();
        PC = FindObjectOfType<PlayerControll>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StaticValue.from = 3;
            PC.myRGB.velocity = new Vector2(0, 0);
            FO.ReadyToGoKing = true;
        }

    }
}
