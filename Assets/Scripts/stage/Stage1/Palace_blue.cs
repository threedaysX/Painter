using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palace_blue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public static bool Palace_Color_blue;
    public GameObject Color_Item;

    // Update is called once per frame
    void Update () {
		if(Palace_Color_blue)
        {
            if(Stage_level.stage_is_on)
            {
                if (Stage_level.stage == 1)
                {
                    Color_Item.SetActive(true);
                }
            }                          
        }
    }
}
