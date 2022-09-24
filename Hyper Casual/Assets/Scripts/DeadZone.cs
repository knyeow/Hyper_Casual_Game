using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bricks") && collision.GetComponent<Rigidbody2D>().velocity.y < -2)
        {
            Debug.Log("you have died");
            collision.gameObject.SetActive(false);
        }
    }
}
