using UnityEngine;

public class RepairKit : MonoBehaviour
{
    [SerializeField] private int repairAmount = 40;
    [SerializeField] private float verticalSpeed = -0.5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector2.up * verticalSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HitScreenEdge(collision))
        {
            Destroy(gameObject);
        }
        if (HitPlayer(collision))
        {
            collision.GetComponent<AircraftController>().OnGetRepaired(repairAmount);
            Destroy(gameObject);
        }
    }

    private bool HitScreenEdge(Collider2D collision) => collision.name == "BottomEdge";
    private bool HitPlayer(Collider2D collision) => collision.CompareTag("Player");
}