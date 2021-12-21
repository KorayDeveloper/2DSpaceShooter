using UnityEngine;

public class DoForSeconds : Condition
{
    private float seconds;

    public DoForSeconds(float seconds)
    {
        this.seconds = seconds;
    }

    public override bool Check(StateController controller)
    {
        seconds -= Time.deltaTime;
        return seconds <= 0;
    }
}