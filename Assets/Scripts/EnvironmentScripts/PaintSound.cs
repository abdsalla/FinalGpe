using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSound : MonoBehaviour {

    public AudioClip paintSound;
    public AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource.clip = paintSound;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayPaint()
    {
        audioSource.Play();
    }
}
