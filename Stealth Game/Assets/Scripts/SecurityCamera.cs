using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] GameObject _gameOverScene;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color colour = new Color(1f, 0f, 0f,0.3f);
            render.material.SetColor("_TintColor", colour);
            _anim.enabled = false;
            StartCoroutine(PlayGameOverCutScene());
        }
    }

    IEnumerator PlayGameOverCutScene()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverScene.SetActive(true);
    }
}
