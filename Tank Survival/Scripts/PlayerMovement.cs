using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private float rotateSpeed = 5;
    private Rigidbody2D rb;
    private float rotate, move;
    private Vector2 moveDirection, mousePos;
    private Camera cam;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        rotate = Input.GetAxisRaw("Horizontal");
        move = Input.GetAxisRaw("Vertical");
    }

    private void Move()
    {
        if (move > .1f)
        {
            rb.velocity = transform.up * moveSpeed;
        }
        else if (move < -.1f)
        {
            rb.velocity = transform.up * -moveSpeed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (rotate > .1f)
        {
            transform.Rotate(0, 0, -rotateSpeed);
        }
        else if (rotate < -.1f)
        {
            transform.Rotate(0, 0, rotateSpeed);
        }

    }
}
