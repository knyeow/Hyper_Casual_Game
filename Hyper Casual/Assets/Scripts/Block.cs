using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float startSpeed;

    private float speed;
    

    [SerializeField] private LayerMask wallLayer;


    [SerializeField] private Transform cameraPosition;

    public float numberOfBlock = 1;

    private Rigidbody2D rb;

    private float direction =1;

    private bool hasTouched=false;

    private float brickTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(6, 7);

        brickTimer += Time.deltaTime;

        speed = startSpeed + StaticCounters.brickCounter * .5f;

        if (hasTouched)
            return;

        ChangeBlocks();

        rb.velocity = new Vector2(speed*direction, rb.velocity.y);
  

        if (IsTouchingWall())
            direction = -direction;

        if (Input.GetMouseButton(0) && brickTimer > 0.1f)
            StartCoroutine(TouchActivs());

    }

    private bool IsTouchingWall()
    {
        RaycastHit2D checkWall = Physics2D.Raycast(transform.position,new Vector2(direction,0),4,wallLayer);

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
        nextBlock.GetComponent<Block>().numberOfBlock = numberOfBlock + 1;
    }
    private IEnumerator TouchActivs()
    {
        brickTimer = 0;
        hasTouched = true;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(0.2f);
        CreateBlock();
    }
    private void SpecialBlocks()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<SpriteRenderer>().color = Color.yellow;

    }
    private void NormalBlocks()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void ChangeBlocks()
    {

        if (numberOfBlock % 20 == 0)
            SpecialBlocks();
        else
            NormalBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (numberOfBlock % 20 == 0)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }
}
