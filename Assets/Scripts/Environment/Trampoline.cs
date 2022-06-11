using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * _jumpForce;
        }
    }
}
