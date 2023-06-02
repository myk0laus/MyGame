using UnityEngine;
using System.Collections.Generic;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _resetTime;
    [SerializeField] private int _damage;
    [SerializeField] private List<AudioClip> _audioImpacts;
    private float _lifetime;
    public void ActivateProjectile()
    {
        _lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float moveSpeed = _speed * Time.deltaTime;
        transform.Translate(moveSpeed, 0, 0);

        _lifetime += Time.deltaTime;
        if (_lifetime > _resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HpManager player = collision.GetComponent<HpManager>();
        if (player != null)
        {
            player.TakeDamage(_damage);
            SoundManager.instance.PlaySound(_audioImpacts[Random.Range(0,_audioImpacts.Count)]);
        }
        gameObject.SetActive(false);

    }
}
