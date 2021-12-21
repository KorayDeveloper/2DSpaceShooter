using System.Collections.Generic;

public abstract class State
{
    public abstract List<Transition> Transitions { get; set; }
    public abstract void OnStateEnter(StateController controller);
    public abstract void UpdateState(StateController controller);
    public abstract void OnStateExit(StateController controller);
    public void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < Transitions.Count; i++)
        {
            if (Transitions[i].Condition.Check(controller))
            {
                if (Transitions[i].TrueState != controller.CurrentState)
                {
                    controller.SetState(Transitions[i].TrueState);
                    break;
                }
            }
            else
            {
                if (Transitions[i].FalseState != controller.CurrentState)
                {
                    controller.SetState(Transitions[i].FalseState);
                    break;
                }
            }
        }
    }
}