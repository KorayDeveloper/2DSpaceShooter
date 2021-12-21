using System;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour
{
    public event Action<int> GetDamage;
    public event Action GetDestroyed;
    public event Action<int> GetRepaired;

    public List<AircraftWeapon> Weapons => weapons;
    public int Durability { get => durability; }

    [Header("Settings")]
    [SerializeField] private float horizontalSpeed = 20f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float dropVelocitySpeed = 2f;
    [SerializeField] private int durability = 100;

    [Header("References")]
    [SerializeField] private List<AircraftWeapon> weapons = new List<AircraftWeapon>();
    [SerializeField] private DamageIndicator damageIndicator = null;
    [SerializeField] private GameObject destroyEffectPrefab = null;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Steer(float motion)
    {
        rb.AddForce((Vector2.right * motion * horizontalSpeed) + Vector2.up * verticalSpeed);
    }

    void FixedUpdate()
    {
        DropVelocity();
    }

    public void OnGetDamage(int damageAmount)
    {
        durability -= damageAmount;
        if (durability > 0)
            damageIndicator.Indicate();
        else
            OnGetDestroyed();

        if (GetDamage != null)
            GetDamage.Invoke(Durability);
    }

    private void OnGetDestroyed()
    {
        if (GetDestroyed != null)
            GetDestroyed.Invoke();

        Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnGetRepaired(int repairAmount)
    {
        durability += repairAmount;
        durability = Mathf.Clamp(durability, 0, 200);
        GetRepaired.Invoke(Durability);
    }

    private void DropVelocity()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.fixedDeltaTime * dropVelocitySpeed);
    }
}