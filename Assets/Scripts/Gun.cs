using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 100f;
    public float range = 100f;
    public Camera fpsCam; // assign your Player Camera
    public ParticleSystem muzzleFlash;

    private bool hasGun;
    void Update()
    {
        if (hasGun && Input.GetButtonDown("Fire1")) // Left mouse by default
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null) muzzleFlash.Play();

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            // Check if we hit an enemy
            SlenderHealth enemy = hit.transform.GetComponent<SlenderHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
    public void PickUpGun()
    {
        hasGun = true;
        Debug.Log("shoot activated!");
    }
}
