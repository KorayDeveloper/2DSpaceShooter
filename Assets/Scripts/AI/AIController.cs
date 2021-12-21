using UnityEngine;

public class AIController : MonoBehaviour
{
    public float DetectDistance { get => detectDistance; }
    public LayerMask DetectLayer;
    public AILaserDetector LaserDetector => laserDetector;
    public float RunSpeed => runSpeed;
    public Transform Target { get; set; }
    public bool HasTarget { get; set; }
    public float AircraftControlMotion { get; set; }

    [SerializeField] private AircraftController aircraft = null;
    [SerializeField] private float detectDistance = 10f;
    [SerializeField] private AILaserDetector laserDetector = null;
    [SerializeField] private float runSpeed = 2f;

    private AITargetController targetController;

    void FixedUpdate()
    {
        ControlAircraft();
    }

    private void ControlAircraft()
    {
        aircraft.Steer(AircraftControlMotion);
    }

    private void OnDisable()
    {
        targetController.TargetGenerated -= SetTarget;
        targetController.TargetDestroyed -= LeaveTarget;
    }

    public void SetTargetController(AITargetController targetController)
    {
        this.targetController = targetController;
        this.targetController.TargetGenerated += SetTarget;
        this.targetController.TargetDestroyed += LeaveTarget;

        if (this.targetController.CurrentTarget != null)
            SetTarget(this.targetController.CurrentTarget);
    }

    private void SetTarget(Transform target)
    {
        Target = target;
        HasTarget = true;
    }

    private void LeaveTarget()
    {
        Target = null;
        HasTarget = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<AircraftController>().OnGetDamage(100);
            aircraft.OnGetDamage(1000);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BottomEdge")
        {
            Destroy(gameObject);
        }
    }
}