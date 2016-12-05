using UnityEngine;
using System.Collections;

public class StatePatternFiend : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseStateFiend chaseState;
    [HideInInspector]
    public PatrolStateFiend patrolState;
    [HideInInspector]
    public AttackStateFiend attackState;
    [HideInInspector]
    public SuperjumpStateFiend superjumpState;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Vector3 chaseDir, targetForAgent;
    [HideInInspector]
    public float distanceToPlayer, wanderTime, timeOfLastEyeContact, sightRange = 15;
    [HideInInspector]
    public bool isSuperjumping = false;

    private void Awake()
    {
        chaseState = new ChaseStateFiend(this);
        patrolState = new PatrolStateFiend(this);
        attackState = new AttackStateFiend(this);
        superjumpState = new SuperjumpStateFiend(this);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        currentState = patrolState;
    }

    void FixedUpdate()
    {
        currentState.UpdateState();
    }

    public void setChaseDir()
    {
        chaseDir = player.transform.position - transform.position;
        distanceToPlayer = chaseDir.magnitude;
    }
}