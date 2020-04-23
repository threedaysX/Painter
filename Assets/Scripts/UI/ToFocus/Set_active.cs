using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_active : MonoBehaviour {

    private bool need_check = false;
    public GameObject need_to_set;

	// Use this for initialization
	void Start () {
        need_check = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(ToFocus.need_Focus && !need_check)
        {
            need_to_set.SetActive(true);
            need_check = true;
        }
	}
}
