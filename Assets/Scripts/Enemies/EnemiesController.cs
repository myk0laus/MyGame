using UnityEngine;

public class EnemiesController : MonoBehaviour
{   
    [SerializeField] protected int _maxHp;
    [SerializeField] protected AudioClip _enemyDeath;
    protected int _hp;
    protected void Start()
    {
        _hp = _maxHp;
    }
    public virtual void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            SoundManager.instance.PlaySound(_enemyDeath);
            Destroy(gameObject);
        }
    }
}

