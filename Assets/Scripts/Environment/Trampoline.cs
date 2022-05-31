using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();     
        if(rb != null)
        {
            //Vector2 jumping = rb.velocity;
            //jumping.y = _jumpForce;
            //rb.velocity = jumping;
            rb.velocity = Vector2.up * _jumpForce;
        }
    }
}
