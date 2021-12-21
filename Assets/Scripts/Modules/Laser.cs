using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private int damageAmount = 20;

    private Rigidbody2D rb;
    private string targetTag;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GoForward();
    }

    public void SetTags(string objectTag, string targetTag)
    {
        gameObject.tag = objectTag;
        this.targetTag = targetTag;
    }

    private void GoForward()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HitScreenEdge(collision))
        {
            Destroy(gameObject);
        }
        else if (HitTarget(collision))
        {
            collision.GetComponent<AircraftController>().OnGetDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    private bool HitScreenEdge(Collider2D collision) => collision.name == "TopEdge" || collision.name == "BottomEdge";
    private bool HitTarget(Collider2D collision) => collision.CompareTag(targetTag);
}