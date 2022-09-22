using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float lerp;
    [SerializeField] private float cameraSpeed;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, cameraSpeed);
    }
    private void Follow()
    {
        Vector3 smoothPoint = Vector3.Lerp(transform.position, new Vector3(0,StaticCounters.brickCounter*0.5f,-15), lerp);
        transform.position = smoothPoint;
    }
}
