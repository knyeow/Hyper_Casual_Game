using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEffect : MonoBehaviour
{

    [SerializeField] private ParticleSystem ps;

    private bool effectPlayed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bricks")&&collision.transform.position.y < transform.position.y &&  Mathf.Abs(collision.transform.position.x - transform.position.x) < 0.15f &&!effectPlayed)
            ps.Play();
            effectPlayed = true;
           
    }
}
