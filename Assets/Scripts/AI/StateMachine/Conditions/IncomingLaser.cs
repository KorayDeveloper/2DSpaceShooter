public class IncomingLaser : Condition
{
    public override bool Check(StateController controller)
    {
        bool incomingLaser = controller.GetComponent<AIController>().LaserDetector.LaserDetected;
        return incomingLaser;
    }
}