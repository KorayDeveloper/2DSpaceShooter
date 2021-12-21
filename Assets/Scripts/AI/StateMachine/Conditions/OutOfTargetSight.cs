using UnityEngine;

public class OutOfTargetSight : Condition
{
    public override bool Check(StateController controller)
    {
        Transform target = controller.GetComponent<AIController>().Target;
        bool outOfTargetSight = Mathf.Abs(target.position.x - controller.transform.position.x) > target.GetComponent<SpriteRenderer>().bounds.size.x;
        return outOfTargetSight;
    }
}