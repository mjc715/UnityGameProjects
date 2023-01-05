using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FollowPlayer : MonoBehaviour
{
    private Camera cam;
    private Transform tf;
    private Rigidbody2D rb;
    public Transform player;
    private float distanceFromPlayer;

    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        Vector3 lookDir = (player.position - tf.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        tf.eulerAngles = new Vector3(0, 0, angle + 180f);
    }

}
