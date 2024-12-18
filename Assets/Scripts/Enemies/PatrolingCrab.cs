using UnityEngine;

public class PatrolingCrab : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float _walkRange;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _dmg;
    [SerializeField] protected float _pushPower;
    [SerializeField] protected bool _faceRight;
    protected float _lastAttackTime;
    protected Vector2 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * _speed;
    }

    protected void Update()
    {
        float currentPosX = transform.position.x;

        if(currentPosX >= _startPos.x + _walkRange && _faceRight)
        {
            FlipX();
        }
        else if (currentPosX <= _startPos.x - _walkRange && !_faceRight)
        {
            FlipX();
        }
    }

    protected void FlipX()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        HealthContainer player = collision.collider.GetComponent<HealthContainer>();
        if(player != null && Time.time - _lastAttackTime > 0.5)
        {
            _lastAttackTime = Time.time;
            player.TakeDamage(_dmg, _pushPower, transform.position.x);
        }          
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_startPos, new Vector3(_walkRange * 2, 1, 0));
    }
}
