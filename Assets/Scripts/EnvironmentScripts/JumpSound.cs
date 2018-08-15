using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour {

    public AudioClip jumpSound;
    public AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource.clip = jumpSound;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayJump()
    {
        audioSource.Play();
    }
}
