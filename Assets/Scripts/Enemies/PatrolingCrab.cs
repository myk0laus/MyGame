using UnityEngine;

public class PatrolingCrab : EnemiesController
{
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float _walkRange;
    [SerializeField] protected float _speed;
    [SerializeField] protected int _dmg;
    [SerializeField] protected float _pushPower;
    [SerializeField] protected bool _faceRight;
    protected float _lastAttackTime;
    protected Vector2 _startPos;

    private void Start()
    {
        base.Start();
        _startPos = transform.position;
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.right * _speed;
    }

    protected void Update()
    {
        float xPos = transform.position.x;

        if(xPos >= _startPos.x + _walkRange && _faceRight)
        {
            FlipX();
        }
        else if (xPos <= _startPos.x - _walkRange && !_faceRight)
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
        HpManager player = collision.collider.GetComponent<HpManager>();
        if(player != null && Time.time - _lastAttackTime > 0.5)
        {
            _lastAttackTime = Time.time;
            player.TakeDamage(_dmg, _pushPower, transform.position.x);
        }          
    }
}
