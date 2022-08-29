using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private AudioClip _enemyDeath;

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            SoundManager.instance.PlaySound(_enemyDeath);
            Destroy(gameObject);
    }
}

