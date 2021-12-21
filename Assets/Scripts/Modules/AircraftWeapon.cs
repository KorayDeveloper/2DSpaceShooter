using UnityEngine;

public class AircraftWeapon : MonoBehaviour
{
    public bool OnCooldown { get => cooldown > 0; }

    [Header("Settings")]
    [SerializeField] private string laserObjectTag = "";
    [SerializeField] private string laserTargetTag = "";
    [SerializeField] private float cooldownLength = 2f;

    [Header("References")]
    [SerializeField] private GameObject laserPrefab = null;

    private float cooldown;

    void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject laserObject = Instantiate(laserPrefab, transform.position, transform.rotation);
        laserObject.GetComponent<Laser>().SetTags(laserObjectTag, laserTargetTag);
        cooldown = cooldownLength;
    }
}