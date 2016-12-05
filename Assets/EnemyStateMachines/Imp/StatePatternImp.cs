using UnityEngine;
using System.Collections;

public class StatePatternImp : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseStateImp chaseState;
    [HideInInspector]
    public PatrolStateImp patrolState;
    [HideInInspector]
    public AttackStateImp attackState;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Vector3 chaseDir, targetForAgent;
    [HideInInspector]
    public float distanceToPlayer, wanderTime, timeOfLastEyeContact, sightRange = 15;

    private void Awake()
    {
        chaseState = new ChaseStateImp(this);
        patrolState = new PatrolStateImp(this);
        attackState = new AttackStateImp(this);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Start()
    {
        currentState = patrolState;
    }
    
    void Update()
    {
        currentState.UpdateState();
    }

    public void setChaseDir()
    {
        chaseDir = player.transform.position - transform.position;
        distanceToPlayer = chaseDir.magnitude;
    }
}