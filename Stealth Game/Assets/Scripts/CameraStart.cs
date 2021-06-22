using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStart : MonoBehaviour
{
    [SerializeField] GameObject cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = cameraPosition.transform.position;
        Camera.main.transform.rotation = cameraPosition.transform.rotation;
        Camera.main.fieldOfView = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
