using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlock : Block
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }



}
