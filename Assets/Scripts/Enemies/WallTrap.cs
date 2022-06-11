using UnityEngine;

public class WallTrap : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private Transform _startPos;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    Vector3 _moveTo;

    void Start()
    {
        _moveTo = _startPos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);

        if (transform.position == _pos1.position)
            _moveTo = _pos2.position;

        else if (transform.position == _pos2.position)
            _moveTo = _pos1.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HpManager player = collision.collider.GetComponent<HpManager>();
        if (player != null)
            player.TakeDamage(_damage);
    }
}
