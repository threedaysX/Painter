using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_close : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        if(Input.anyKey)
        {
            this.gameObject.SetActive(false);
            StaticValue.StartTalk = true;
            ToFocus.need_Focus = false;
        }
    }
}
