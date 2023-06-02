using UnityEngine;
using UnityEngine.Audio;

public class Fireball : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip _soundExplosion;
    [SerializeField] private GameObject _explosionEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(_soundExplosion);
        EnemiesController enemy = collision.collider.GetComponent<EnemiesController>();
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }  
        Destroy(gameObject);
    }
}
