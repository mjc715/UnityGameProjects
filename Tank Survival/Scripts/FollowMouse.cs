using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FollowMouse : MonoBehaviour
{
    Vector3 mousePos;
    private Camera cam;
    private Transform tf;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = UtilsClass.GetMouseWorldPosition();
        Vector3 lookDir = (mousePos - tf.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 180f;
        tf.eulerAngles = new Vector3(0, 0, angle);
    }

}
