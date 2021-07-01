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
    [SerializeField] GameObject _cardOnGuard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _grabKeyScene.SetActive(true);
            _player.gameObject.SetActive(false);
            StartCoroutine(ReenableObejects());
            StartCoroutine(RemoveCardFromGuard());
            GameManager.Instance.HasCard = true;
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

    IEnumerator RemoveCardFromGuard()
    {
        yield return new WaitForSeconds(3.26f);
        _cardOnGuard.SetActive(false);
    }
}
