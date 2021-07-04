using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("Audio manager is null");
            }
            return _instance;
        }
    }

    [SerializeField] AudioSource voiceOver;

    private void Awake()
    {
        _instance = this;
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }
}
