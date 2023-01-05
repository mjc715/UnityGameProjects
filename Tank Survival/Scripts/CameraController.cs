using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, 2.82f, 33.17f), Mathf.Clamp(player.position.y, -20f, .91f), transform.position.z);
    }
}
