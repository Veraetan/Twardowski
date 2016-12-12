using UnityEngine;
using System.Collections;

public class StatePatternFiend : MonoBehaviour
{

    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public IEnemyState currentState, previousState;
    [HideInInspector]
    public ChaseStateFiend chaseState;
    [HideInInspector]
    public PatrolStateFiend patrolState;
    [HideInInspector]
    public AttackStateFiend attackState;
    [HideInInspector]
    public SuperjumpStateFiend superjumpState;
    [HideInInspector]
    public OffMeshLinkStateFiend offMeshLinkState;
    [HideInInspector]
    public DazeStateFiend dazeState;
    [HideInInspector]
    public NavMeshAgent agent;
    [HideInInspector]
    public Vector3 chaseDir, targetForAgent;
    [HideInInspector]
    public float distanceToPlayer, wanderTime, timeOfLastEyeContact, sightRange = 15, dazeTime;
    [HideInInspector]
    public bool isSuperjumping = false, isAttacking = false, isDazed = false, shouldBeDazed = false;
    [HideInInspector]
    public Color originalColor;

    private void Awake()
    {
        chaseState = new ChaseStateFiend(this);
        patrolState = new PatrolStateFiend(this);
        attackState = new AttackStateFiend(this);
        dazeState = new DazeStateFiend(this);
        superjumpState = new SuperjumpStateFiend(this);
        offMeshLinkState = new OffMeshLinkStateFiend(this);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        currentState = patrolState;
    }

    void LateUpdate()
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