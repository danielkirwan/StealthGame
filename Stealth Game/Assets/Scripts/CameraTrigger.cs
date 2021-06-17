using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //[SerializeField] Camera cam;
    [SerializeField] GameObject cameraPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered trigger");
            Camera.main.transform.position = cameraPosition.transform.position;
            Camera.main.transform.rotation = cameraPosition.transform.rotation;
        }
    }
}
