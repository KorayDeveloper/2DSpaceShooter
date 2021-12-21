using System.Collections.Generic;

public class Patrol : State
{
    public override List<Transition> Transitions { get; set; }

    public override void OnStateEnter(StateController controller)
    {
    }

    public override void OnStateExit(StateController controller)
    {
    }

    public override void UpdateState(StateController controller)
    {
    }
}