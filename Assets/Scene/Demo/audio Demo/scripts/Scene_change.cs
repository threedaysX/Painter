using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Scene nowScene = SceneManager.GetActiveScene();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(nowScene.name);
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            if (nowScene.name == "testA")
            {
                SceneManager.LoadScene("testB");
            }
            else
            {
                SceneManager.LoadScene("testA");
            }
        }
    }
}
