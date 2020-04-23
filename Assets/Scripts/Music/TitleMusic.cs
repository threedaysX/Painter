using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMusic : MonoBehaviour {

    private static TitleMusic instance;

    private AudioSource Title_BGM;

    // Use this for initialization
    void Start()
    {
        Title_BGM = this.gameObject.GetComponent<AudioSource>();
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
        Scene nowScene = SceneManager.GetActiveScene();
        if(nowScene.name == "FT" || nowScene.name == "標題畫面")
        {
            if(!Title_BGM.isPlaying)
            {
                Title_BGM.Play();
                Title_BGM.loop = true;
            }
        }
        else
        {
            if(Title_BGM.isPlaying)
            {
                Title_BGM.Stop();
            }
            Destroy(this.gameObject);
        }
	}
}
