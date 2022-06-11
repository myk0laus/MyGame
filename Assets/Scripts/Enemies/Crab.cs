using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private Transform _groundDetection;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private bool _movingRight;
    [SerializeField] private int _damage;
    private float _timer;

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        RaycastHit2D ray = Physics2D.Raycast(_groundDetection.position, Vector2.down, _distance);

        if (!ray.collider)
        {
            if (_movingRight)
            {
                transform.Rotate(0, 180, 0);
                _movingRight = !_movingRight;
            }
            else
            {
                transform.Rotate(0, 0, 0);
                _movingRight = !_movingRight;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HpManager player = collision.collider.GetComponent<HpManager>();
        if (player != null && Time.time - _timer > 0.5)
        {
            _timer = Time.time;
            player.TakeDamage(_damage);
        }
    }
}

