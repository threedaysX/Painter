using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 標題圖移動 : MonoBehaviour {

	public GameObject thing;
	public GameObject end;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		

			thing.transform.Translate (0, 5 * Time.deltaTime, 0);


	}




}
