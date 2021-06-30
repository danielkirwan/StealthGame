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
    [SerializeField] GameObject _coin;
    [SerializeField] AudioClip _coinDrop;
    private bool _coinThrown;


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

        if (Input.GetMouseButtonDown(1) && _coinThrown == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _anim.SetTrigger("Throw");
                
                _coinThrown = true;
                Instantiate(_coin, hit.point, Quaternion.identity);

                
                AudioSource.PlayClipAtPoint(_coinDrop, hit.point);
                SendGuardsToCoinPosition(hit.point);
            }
           
        }

    }

    private void SendGuardsToCoinPosition(Vector3 coin_pos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        foreach(GameObject guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator guardAnimator = guard.GetComponent<Animator>();

            //float distance = Vector3.Distance(guardTransform.position, coin_pos);
            currentGuard._coinToss = true;
            currentAgent.SetDestination(coin_pos);
            //change the vector in the guard script
            currentGuard._coinPosition = coin_pos;
            guardAnimator.SetBool("Walk", true);
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
