using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazard : MonoBehaviour
{
    [SerializeField] private int _dmg;
    private Rigidbody2D _rb;
    private float _attackDelay;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if(player != null)
        {
            _rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HpManager player = collision.collider.GetComponent<HpManager>();
        if(player != null && Time.time - _attackDelay > 0.5)
        {
            _attackDelay = Time.time;
            player.TakeDamage(_dmg);
        }
    }
}
