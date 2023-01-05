using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            anim.SetTrigger("hit");
            collider.gameObject.GetComponent<Enemy>().Die();
            rb.bodyType = RigidbodyType2D.Static;
        }
        else if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Player>().Die();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("hit");
        }
        else if (collider.CompareTag("Projectile"))
        {
            anim.SetTrigger("hit");
            rb.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            anim.SetTrigger("hit");
            rb.bodyType = RigidbodyType2D.Static;
        }

    }

    public void KillAnim()
    {
        Destroy(gameObject);
    }
}
