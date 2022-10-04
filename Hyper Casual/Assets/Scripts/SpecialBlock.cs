using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlock : Block
{

    private bool oneTime = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;



        if (!oneTime)
        {
            GameObject[] _go = GameObject.FindGameObjectsWithTag("Bricks");

            for (int i = 0; i < 20; i++)
            {
                if (_go.Length > 20 && _go[i] !=this.gameObject)
                     Destroy(_go[i]);
            }
            oneTime = true;
        }



        }

    }




