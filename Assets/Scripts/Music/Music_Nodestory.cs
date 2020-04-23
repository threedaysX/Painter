using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Nodestory : MonoBehaviour {

    private static Music_Nodestory instance;

    private AudioSource Stage_BGM;

    public static bool music_need_quite = false;
    private bool record = false;
    private float nowVolume = 1;

    // Use this for initialization
    void Start () {
        Stage_BGM = this.gameObject.GetComponent<AudioSource>();
        if (!instance)
        {
            instance = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

	}

    // Update is called once per frame
    void Update()
    {
        if (Stage_level.stage_is_on)
        {
            if (Stage_level.stage == 1)   ///判斷第幾關
            {
                if (!Stage_BGM.isPlaying)
                {
                    Stage_BGM.Play();
                    Stage_BGM.loop = true;
                }
            }
        }     
        else
        {
            if (Stage_BGM.isPlaying)
            {
                Stage_BGM.Stop();
            }
        }        
    }
}
