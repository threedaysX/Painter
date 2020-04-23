using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_nodestroy : MonoBehaviour {

    private static Player_nodestroy instance;

    // Use this for initialization
    void Start () {
        if (!instance)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
