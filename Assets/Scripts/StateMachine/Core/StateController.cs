using UnityEngine;

public class StateController : MonoBehaviour
{
    private State currentState;
    public State CurrentState => currentState;

    void Update()
    {
        currentState.CheckTransitions(this);
        currentState.UpdateState(this);
    }

    public void SetState(State state)
    {
        if (state != currentState)
        {
            if (currentState != null)
                currentState.OnStateExit(this);
            currentState = state;
            currentState.OnStateEnter(this);
        }
    }
}