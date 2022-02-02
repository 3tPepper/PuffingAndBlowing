using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    public AudioClip walking;
    public AudioClip catching;
    public AudioClip uiClick;

    AudioSource audiosource;
    public GameObject pAudio;
    public GameObject uAudio;

    private static AudioControll _instance;
    public static AudioControll instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<AudioControll>();
            }
            return _instance;
        }
    }


    public void AudioSwitch(string action)
    {
        switch (action)
        {
            case "WALK":
                audiosource = pAudio.GetComponent<AudioSource>();
                audiosource.clip = walking;
                if (!audiosource.isPlaying)
                {
                    audiosource.Play();
                }
                break;
            case "CATCH":
                audiosource = pAudio.GetComponent<AudioSource>();
                audiosource.clip = catching;
                audiosource.Play();
                break;
            case "UICLICK":
                audiosource = uAudio.GetComponent<AudioSource>();
                audiosource.clip = uiClick;
                audiosource.Play();
                break;
            default:
                break;
        }

    }

}
