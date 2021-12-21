using System;
using UnityEngine;

public class AITargetController : MonoBehaviour
{
    public event Action<Transform> TargetGenerated;
    public event Action TargetDestroyed;
    private Transform currentTarget;
    public Transform CurrentTarget => currentTarget;

    [SerializeField] private PlayerController playerController = null;

    private void OnEnable()
    {
        playerController.AircraftGenerated += OnTargetGenerated;
        playerController.AircraftDestroyed += OnTargetDestroyed;
    }

    private void OnDisable()
    {
        playerController.AircraftGenerated -= OnTargetGenerated;
        playerController.AircraftDestroyed -= OnTargetDestroyed;
    }

    public void OnTargetGenerated(Transform target)
    {
        currentTarget = target;
        if (TargetGenerated != null)
            TargetGenerated.Invoke(target);
    }

    public void OnTargetDestroyed()
    {
        if (TargetDestroyed != null)
            TargetDestroyed.Invoke();
    }
}