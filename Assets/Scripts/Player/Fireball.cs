using UnityEngine;
using UnityEngine.Audio;

public class Fireball : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip _soundExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(_soundExplosion);
        EnemiesController enemy = collision.collider.GetComponent<EnemiesController>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }
       
        Destroy(gameObject);
    }
}
