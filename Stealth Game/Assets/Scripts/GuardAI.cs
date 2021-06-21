using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] List<Transform> _waypoints;
    [SerializeField] private int _currentTarget = 0;
    private bool _reverse;
    private bool _targetReached;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_waypoints.Count > 0 && _waypoints[_currentTarget] != null)
        {
            _agent.SetDestination(_waypoints[_currentTarget].position);
            float distance = Vector3.Distance(transform.position, _waypoints[_currentTarget].position);
            if(distance < 1f && _targetReached == false)
            {
                
                if (_reverse)
                {
                    _currentTarget--;
                    if(_currentTarget == 0)
                    {
                        _reverse = false;
                        StartCoroutine(WaitBeforeMoving());
                        _currentTarget = 0;
                        
                    }
                }
                else
                {
                    _currentTarget++;
                    if (_currentTarget == _waypoints.Count)
                    {
                        StartCoroutine(WaitBeforeMoving());
                        _reverse = true;
                        _currentTarget--;
                    }
                }
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        _targetReached = true;
        int random = Random.Range(2, 5);
        Debug.Log(random);
        yield return new WaitForSeconds(random);
        _targetReached = false;
    }

}
