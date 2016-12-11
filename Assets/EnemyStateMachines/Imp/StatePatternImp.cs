using UnityEngine;
using System.Collections;

public class StatePatternImp : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public IEnemyState currentState, previousState;
    [HideInInspector]
    public ChaseStateImp chaseState;
    [HideInInspector]
    public PatrolStateImp patrolState;
    [HideInInspector]
    public AttackStateImp attackState;
    [HideInInspector]
    public OffMeshLinkStateImp offMeshLinkState;
    [HideInInspector]
    public DazeStateImp dazeState;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Vector3 chaseDir, targetForAgent;
    [HideInInspector]
    public float distanceToPlayer, wanderTime, timeOfLastEyeContact, sightRange = 15, dazeTime;
    [HideInInspector]
    public bool isAttacking = false, shouldBeDazed = false, isDazed = false;

    private void Awake()
    {
        chaseState = new ChaseStateImp(this);
        patrolState = new PatrolStateImp(this);
        attackState = new AttackStateImp(this);
        offMeshLinkState = new OffMeshLinkStateImp(this);
        dazeState = new DazeStateImp(this);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Start()
    {
        currentState = patrolState;
    }
    
    void FixedUpdate()
    {
        setChaseDir();
        currentState.UpdateState();
    }

    public void setChaseDir()
    {
        chaseDir = player.transform.position - transform.position;
        distanceToPlayer = chaseDir.magnitude;
    }
}