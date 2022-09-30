    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform cam;

    [SerializeField] private float moveSpeed;



    private void Update()
    {
        transform.Translate(0, -1 * moveSpeed, 0);

        if (cam.position.y >= transform.position.y + 73.53406f)
            transform.position = new Vector2(transform.position.x, cam.position.y+ 73.53406f);
    }
}
