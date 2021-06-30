using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKey : MonoBehaviour
{
    [SerializeField] GameObject _grabKeyScene;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _securityGuard;
    [SerializeField] Collider _collider;
    [SerializeField] GameObject _cameraObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _grabKeyScene.SetActive(true);
            _player.gameObject.SetActive(false);
            StartCoroutine(ReenableObejects());
        }
    }

IEnumerator ReenableObejects()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(5.8f);
        _grabKeyScene.SetActive(false);

        //Debug.Log("Should be activating player and guard objects");
        //_player.SetActive(true);
        //_securityGuard.SetActive(true);
        _player.gameObject.SetActive(true);
        _securityGuard.gameObject.SetActive(true);
        Camera.main.transform.position = _cameraObject.transform.position;
        Camera.main.transform.rotation = _cameraObject.transform.rotation;
    }
}
