using System.Collections.Generic;
using UnityEngine;

public class Run : State
{
    public override List<Transition> Transitions { get; set; }

    private int runDirection;

    public override void OnStateEnter(StateController controller)
    {
        runDirection = Random.Range(1, 3);
        if (runDirection == 2)
            runDirection = -1;

        controller.GetComponent<AIController>().LaserDetector.LaserDetected = false;
    }

    public override void OnStateExit(StateController controller)
    {
    }

    public override void UpdateState(StateController controller)
    {
        MoveAwayFromTarget(controller.GetComponent<AIController>(), controller.GetComponent<AIController>().Target);
    }

    private void MoveAwayFromTarget(AIController aiController, Transform target)
    {
        aiController.AircraftControlMotion = runDirection * aiController.RunSpeed;
    }
}