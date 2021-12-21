using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public override List<Transition> Transitions { get; set; }

    public override void UpdateState(StateController controller)
    {
        MoveTowardsTarget(controller.GetComponent<AIController>(), controller.GetComponent<AIController>().Target);
    }

    private void MoveTowardsTarget(AIController aiController, Transform target)
    {
        aiController.AircraftControlMotion = (target.position - aiController.transform.position).normalized.x;
    }

    public override void OnStateEnter(StateController controller)
    {
    }

    public override void OnStateExit(StateController controller)
    {
        Rigidbody2D rb = controller.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, rb.velocity.y);
        controller.GetComponent<AIController>().AircraftControlMotion = 0;
    }
}