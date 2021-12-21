using UnityEngine;

public class AILaserDetector : MonoBehaviour
{
    public bool LaserDetected { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLaser"))
            LaserDetected = true;
    }
}