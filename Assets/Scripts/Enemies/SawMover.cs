using UnityEngine;

public class SawMover : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private Transform _startPos;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    Vector2 _moveTo;

    private void Start()
    {
        _moveTo = _startPos.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);

        if (transform.position == _pos1.position)
            _moveTo = _pos2.position;
        else if (transform.position == _pos2.position)
            _moveTo = _pos1.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HpManager player = collision.GetComponent<HpManager>();
        if (player != null)
        {
            player.TakeDamage(_damage);
        }
    }
}
