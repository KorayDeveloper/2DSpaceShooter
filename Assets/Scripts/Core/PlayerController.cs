using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Transform> AircraftGenerated;
    public event Action AircraftDestroyed;
    public bool TouchOverControlPad { get; set; }
    public float SteerMotion { get; set; }

    [Header("References")]
    [SerializeField] private GameObject aircraftPrefab = null;
    [SerializeField] private DurabilityBar durabilityBar = null;
    [SerializeField] private GameController gameController = null;

    private AircraftController aircraft;

    private void OnEnable()
    {
        gameController.GameStart += GenerateAircraft;
    }

    private void OnDisable()
    {
        gameController.GameStart -= GenerateAircraft;
    }

    void FixedUpdate()
    {
        if (aircraft != null)
            SteerAircraft();
    }

    private void GenerateAircraft()
    {
        GameObject aircraftObject = Instantiate(aircraftPrefab);
        aircraft = aircraftObject.GetComponent<AircraftController>();
        aircraft.GetDamage += UpdateDurabilityBar;
        aircraft.GetRepaired += UpdateDurabilityBar;
        aircraft.GetDestroyed += OnAircraftDestroyed;
        aircraft.GetDestroyed += gameController.OnGameOver;
        durabilityBar.MaxValue = aircraft.Durability;
        durabilityBar.Value = aircraft.Durability;
        OnAircraftGenerated(aircraft.transform);
    }

    private void OnAircraftGenerated(Transform aircraft)
    {
        if (AircraftGenerated != null)
            AircraftGenerated.Invoke(aircraft);
    }

    private void OnAircraftDestroyed()
    {
        if (AircraftDestroyed != null)
            AircraftDestroyed.Invoke();
    }

    private void SteerAircraft()
    {
        aircraft.Steer(SteerMotion);
    }

    public void ShootAircraft()
    {
        foreach (AircraftWeapon weapon in aircraft.Weapons)
        {
            if (!weapon.OnCooldown)
            {
                weapon.Shoot();
            }
        }
    }

    private void UpdateDurabilityBar(int durability)
    {
        durabilityBar.Value = durability;
    }
}