using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPool : MonoBehaviour {

    private FadeOut FO;
    private PlayerControll PC;

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
            StaticValue.from = 2;
            PC.myRGB.velocity = new Vector2(0, 0);
            FO.ReadyToGoWater = true;
        }

    }
}
