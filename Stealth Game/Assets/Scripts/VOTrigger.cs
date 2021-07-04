using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOTrigger : MonoBehaviour
{
    //[SerializeField] AudioSource _voiceOver;
    [SerializeField] AudioClip _voiceOver;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_voiceOver.Play();
            AudioManager.Instance.PlayVoiceOver(_voiceOver);
        }
    }
}
