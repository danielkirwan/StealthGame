using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    //[SerializeField] Camera cam;
    [SerializeField] GameObject cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
