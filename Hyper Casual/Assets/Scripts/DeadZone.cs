using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;

    [SerializeField]GameObject mainGame;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bricks") && collision.GetComponent<Rigidbody2D>().velocity.y < -3.5f)
        {

            StaticCounters.isGameEnd = true;
            collision.gameObject.SetActive(false);
            gameOverScreen.Setup();
            
        }


    }
}
