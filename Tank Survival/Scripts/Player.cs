using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject turret;
    [SerializeField] private AudioSource deathSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        turret = GameObject.Find("Turret");
    }


    public void Die()
    {
        Destroy(turret);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSound.Play();
        float timer = 0;
        while (timer < 1.5f)
        {
            timer += Time.deltaTime;
        }
        UIManager.instance.GameOver();

    }

    public void KillAnim()
    {
        Destroy(gameObject);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
