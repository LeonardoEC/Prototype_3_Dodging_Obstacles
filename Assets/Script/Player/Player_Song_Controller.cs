using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Song_Controller : MonoBehaviour
{
    [HideInInspector] AudioSource playerAudioSource;

    public AudioClip playerJumpSong;
    public AudioClip playerCrashSong;

    void OnEnable()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySong(string song)
    {
        switch (song)
        {
            case "jump":
                playerAudioSource.PlayOneShot(playerJumpSong);
                break;
            case "crash":
                playerAudioSource.PlayOneShot(playerCrashSong);
                break;
        }
    }

}
