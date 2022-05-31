using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayForDamage = 1f;
    private float _lastDmageTime;
    private HpManager _hp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HpManager hp = collision.GetComponent<HpManager>();
        if (hp != null)
            _hp = hp;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HpManager hp = collision.GetComponent<HpManager>();
        if (hp == _hp)
            _hp = null;
    }

    private void Update()
    {
        if (_hp != null && Time.time - _lastDmageTime > _delayForDamage)
        {
            _lastDmageTime = Time.time;
            _hp.TakeDamage(_damage);
        }
    }
}
