using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    [Header("===== Nav Agent Variables=====")]
    public State activeState;
    //public AI_Stats enemyStats;
    public MageStats mageStats;
    public Transform eyes;


    [Header("===== States and Patrol Points=====")]
    public List<Transform> wayPoints;
    public State remainState;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public float distance;
    [HideInInspector] public Transform chaseTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, chaseTarget.position);
        activeState.UpdateState(this);
        Debug.Log(activeState);
    }

    private void OnDrawGizmos()
    {
        if (activeState != null && eyes != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawWireSphere(eyes.position, mageStats.sphereLookRadius);
        }
    }

    public void TransitionState(State nextState)
    {
        if(nextState != remainState)
        {
            activeState = nextState;
        }
    }

    public bool CheckTime(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);

    }

    public void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
