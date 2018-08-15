using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailMusic : MonoBehaviour {

    public AudioClip failMusic;
    public AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource.clip = failMusic;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayFM()
    {
        audioSource.Play();
    }
}