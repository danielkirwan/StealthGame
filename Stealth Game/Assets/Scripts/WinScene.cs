using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    [SerializeField] GameObject _winScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GameManager.Instance.HasCard)
        {
            _winScene.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You must have the key to proceed");
        }
    }
}
