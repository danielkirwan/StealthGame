using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent player;
    bool _isWalking = false;
    [SerializeField] Animator _anim;
    // Start is called before the first frame update
    float _destinationThreshold = 1f;
    Vector3 _targetPosition;
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Hit: " + hit.point);
                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = hit.point;
                player.SetDestination(hit.point);
                _targetPosition = hit.point;
                _isWalking = true;
                _anim.SetBool("Walk", true);
            }


        }
        if (_isWalking)
        {
            CheckDestinationReached();
        }
        

    }


    private void CheckDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _targetPosition);
        if(distanceToTarget < _destinationThreshold)
        {
            _anim.SetBool("Walk", false);
            _isWalking = false;
        }
    }
}
