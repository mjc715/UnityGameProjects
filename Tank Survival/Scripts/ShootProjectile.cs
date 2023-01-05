using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private AudioSource shootSound;
    private float nextFire = 0f;

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * -bulletForce, ForceMode2D.Impulse);
        shootSound.Play();

    }

}
