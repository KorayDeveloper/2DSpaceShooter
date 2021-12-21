public class HasTarget : Condition
{
    public override bool Check(StateController controller)
    {
        bool hasTarget = controller.GetComponent<AIController>().HasTarget;
        return hasTarget;
    }
}