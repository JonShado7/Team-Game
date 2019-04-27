using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    [Header("===== Nav Agent Variables=====")]
    public State activeState;
    public AI_Stats enemyStats;
    public Transform eyes;

    [HideInInspector] public NavMeshAgent agent;
    public List<Transform> wayPoints;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform chaseTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        activeState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (activeState != null && eyes != null)
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.sphereLookRadius);
        }
    }
}
