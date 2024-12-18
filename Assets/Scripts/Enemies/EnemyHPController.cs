using UnityEngine;

public class EnemyHPController : MonoBehaviour, IDamageable
{   
    [SerializeField] protected int _maxHp;
    [SerializeField] protected AudioClip _enemyDeath;
    protected int _hp;
     
    void Start()
    {
        _hp = _maxHp;
    }

    public virtual void ApplyDamage(int damage)
    {
        _hp -= damage;
        Debug.Log(_hp);
        if (_hp <= 0)
        {
            SoundManager.instance.PlaySound(_enemyDeath);
            Destroy(gameObject);
        }
    }
}

