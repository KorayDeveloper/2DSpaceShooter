using UnityEngine;

public class TargetInSight : Condition
{
    public override bool Check(StateController controller)
    {
        RaycastHit2D hit = Physics2D.Raycast(controller.transform.position + controller.transform.up, controller.transform.up, controller.GetComponent<AIController>().DetectDistance, controller.GetComponent<AIController>().DetectLayer);
        bool targetInSight = hit.collider != null && hit.collider.CompareTag("Player");
        return targetInSight;
    }
}