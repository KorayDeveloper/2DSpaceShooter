using System.Collections.Generic;

public class Attack : State
{
    public override List<Transition> Transitions { get; set; }

    public override void UpdateState(StateController controller)
    {
        AircraftController aircraft = controller.GetComponent<AircraftController>();
        foreach (AircraftWeapon weapon in aircraft.Weapons)
        {
            if (!weapon.OnCooldown)
            {
                weapon.Shoot();
            }
        }
    }

    public override void OnStateEnter(StateController controller)
    {
    }

    public override void OnStateExit(StateController controller)
    {
    }
}