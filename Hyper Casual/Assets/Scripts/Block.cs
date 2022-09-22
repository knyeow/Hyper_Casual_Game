using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private LayerMask wallLayer;


    [SerializeField] private Transform cameraPosition;

    private Rigidbody2D rb;

    private float direction;

    private bool hasTouched=false;

    private float brickTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    
    void FixedUpdate()
    {
        
        brickTimer += Time.deltaTime;

        if (hasTouched)
            return;

        direction = Mathf.Sign(rb.velocity.x);

        if (IsTouchingWall())
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);

        if (Input.GetMouseButton(0)&&brickTimer >0.1f)
            TouchActivities();

    }

    private bool IsTouchingWall()
    {
        RaycastHit2D checkWall = Physics2D.Raycast(transform.position,new Vector2(direction,0), 1,wallLayer);

        if (checkWall)
            return true;

        return false;
    }
    private void TouchActivities()
    {
        
        brickTimer = 0;
        hasTouched = true;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        CreateBlock();
    }

    private void CreateBlock()
    {
        StaticCounters.brickCounter++;
        GameObject nextBlock = Instantiate(this.gameObject);
        nextBlock.transform.position = cameraPosition.position + new Vector3(0,-2,25);
        nextBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

}
