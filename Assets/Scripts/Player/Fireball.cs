using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private AudioClip _soundExplosion;
    [SerializeField] private GameObject _explosionEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySound(_soundExplosion);

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("Hit");
            damageable.ApplyDamage(_damage);
            Destroy(gameObject);
        }

        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
