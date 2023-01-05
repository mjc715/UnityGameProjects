using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] AudioSource enemyDeathSound;
    [SerializeField] EnemyBehavior enemyBehavior;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        Destroy(transform.GetChild(0).gameObject);
        rb.bodyType = RigidbodyType2D.Static;
        UIManager.instance.killCount++;
        UIManager.instance.UpdateKillCounterUI();
        anim.SetTrigger("death");
        enemyDeathSound.Play();
        enemyBehavior.dead = true;
    }

    public void KillAnim()
    {
        Destroy(gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    }

}
