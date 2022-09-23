using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float lerp;
    [SerializeField] private float cameraStartSpeed;

    private float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //speed = cameraStartSpeed + StaticCounters.brickCounter * 0.01f;
        // rb.velocity = new Vector2(0, speed);
        //  transform.position = new Vector3(0, StaticCounters.brickCounter,-15);
      Follow();
        
    }
    private void Follow()
    {
        Vector3 smoothPoint = Vector3.Lerp(transform.position, new Vector3(0,(int)StaticCounters.brickCounter*2,-15), lerp);
        transform.position = smoothPoint;
    }
}
