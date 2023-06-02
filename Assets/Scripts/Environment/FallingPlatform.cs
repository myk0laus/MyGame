using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float _fallingTime;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMover player = collision.collider.GetComponent<PlayerMover>();
        if(player != null)
        {
            Invoke(nameof(MakeItDynamic), _fallingTime);
        }
    }

    private void MakeItDynamic()
    {
        rb.isKinematic = false;
    }
}
