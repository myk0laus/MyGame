using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemiesController enemy = collision.collider.GetComponent<EnemiesController>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
