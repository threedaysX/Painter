using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeModifying : MonoBehaviour {

    public AudioSource audios;

    public float volumn = 1f;

    public static VolumeModifying instance;

	// Use this for initialization
	void Start () {
        audios = GetComponent<AudioSource>();
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        audios.volume = volumn;
	}

    public void SetVolume(float vol)
    {
        volumn = vol;
    }
}
