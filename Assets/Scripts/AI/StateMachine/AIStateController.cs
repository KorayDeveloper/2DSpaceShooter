using System.Collections.Generic;

public class AIStateController : StateController
{
    private Patrol patrolState;
    public Patrol PatrolState => patrolState;
    private Chase chaseState;
    public Chase ChaseState => chaseState;
    private Attack attackState;
    public Attack AttackState => attackState;
    private Run runState;
    public Run RunState => runState;

    void Awake()
    {
        patrolState = new Patrol();
        chaseState = new Chase();
        attackState = new Attack();
        runState = new Run();

        patrolState.Transitions = new List<Transition>()
        {
            new Transition(new HasTarget(), ChaseState, PatrolState)
        };
        chaseState.Transitions = new List<Transition>()
        {
            new Transition(new HasTarget(), ChaseState, PatrolState),
            new Transition(new TargetInSight(), AttackState, ChaseState),
        };
        attackState.Transitions = new List<Transition>()
        {
            new Transition(new HasTarget(), AttackState, PatrolState),
            new Transition(new IncomingLaser(), RunState, AttackState),
            new Transition(new TargetInSight(), AttackState, ChaseState)
        };
        runState.Transitions = new List<Transition>()
        {
            new Transition(new HasTarget(), RunState, PatrolState),
            new Transition(new DoForSeconds(0.5f), ChaseState, RunState)
        };
    }

    void Start()
    {
        SetState(PatrolState);
    }
}