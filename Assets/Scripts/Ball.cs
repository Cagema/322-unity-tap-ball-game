using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.position.y < -GameManager.Single.RightUpperCorner.y)
        {
            Destroy(gameObject);
            GameManager.Single.Lives--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Single.ResetMult();
    }
}
