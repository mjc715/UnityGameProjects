using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public float lineOfSite;
    [SerializeField] private Transform player;
    public float shootingRange;
    public float distanceFromPlayer;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private GameObject bulletPrefab;
    private float nextFire = 0f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float retreatRange;
    private Rigidbody2D rb;
    [SerializeField] AudioSource enemyShootSound;
    [HideInInspector] public bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceFromPlayer < retreatRange && !dead)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.forward, 2f);
            if (!hit.rigidbody.gameObject.CompareTag("Colliders"))
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        if (distanceFromPlayer <= shootingRange && Time.time > nextFire)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        Vector2 shootDir = (player.transform.position - transform.position).normalized * speed;
        nextFire = Time.time + fireRate;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootDir * bulletForce, ForceMode2D.Impulse);
        enemyShootSound.Play();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
        Gizmos.DrawWireSphere(transform.position, retreatRange);

    }
}
