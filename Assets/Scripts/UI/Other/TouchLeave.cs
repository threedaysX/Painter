using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLeave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Application.LoadLevel("標題畫面");
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Finish") {
			Debug.Log ("In");
			Application.LoadLevel ("標題畫面");
		}
	}
}
