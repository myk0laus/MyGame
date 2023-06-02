using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] public Rigidbody2D _rigidBody;
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForce;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsCell;
    [SerializeField] private Collider2D _headCollider;
    [SerializeField] private float _headCheckergRadius;
    [SerializeField] private Transform _headChecker;
    [SerializeField] private bool _faceRight;

    [Header("Animation")]
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runAnimatorKey;
    [SerializeField] private string _jumpAnimatorKey;
    [SerializeField] private string _crouchAnimatorKey;
    [SerializeField] private string _hurtAnimatorKey;
    private float _lastHurtTime;

    public float LastHurtTime 
    {
        get => _lastHurtTime;
        set
        {
            _lastHurtTime = value;
        }
    }
    public string HurtAnimatorKey => _hurtAnimatorKey;    

    public Joystick joystick;
    private float _horizontalDirection;
    private float _verticaDirection;
    private bool _jump;
    private bool _crawl;
    public float JumpForce
    {
        get => _jumpForce;
        set
        {
            _jumpForce = value;
        }
    }

    public bool FaceRight => _faceRight;
    public bool CanClimb { private get; set; }

    private void Update()
    {
        if (_animator.GetBool(_hurtAnimatorKey))
        {
            return;
        }

        _horizontalDirection = joystick.Horizontal;
        _verticaDirection = joystick.Vertical;

        _animator.SetFloat(_runAnimatorKey, Mathf.Abs(_horizontalDirection));

        if (_horizontalDirection < 0 && _faceRight)
        {
            FlipX();
        }
        else if (_horizontalDirection > 0 && !_faceRight)
        {
            FlipX();
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _jump = true;
        //}
        //_crawl = Input.GetKey(KeyCode.LeftControl);
        //_crawl = false;
    }

    private void FixedUpdate()
    {
        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);

        if (_animator.GetBool(_hurtAnimatorKey))
        {
            if(Time.time - _lastHurtTime > 0.2 && canJump)
            {               
                _animator.SetBool(_hurtAnimatorKey, false);
            }
            return;
        }

        //if (_animator.GetBool(_hurtAnimationKey))
        //{
        //    if (Time.time - _lastPushTime > 0.2f && canJump)
        //        _animator.SetBool(_hurtAnimationKey, false);

        //    return;
        //}

        bool canStand = !Physics2D.OverlapCircle(_headChecker.position, _headCheckergRadius, _whatIsCell);
        _rigidBody.velocity = new Vector2(_horizontalDirection * _speed, _rigidBody.velocity.y);

        if (CanClimb)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _verticaDirection * _speed);
            _rigidBody.gravityScale = 0;
        }
        else
        {
            _rigidBody.gravityScale = 2.5f;
        }
       
        _headCollider.enabled = !_crawl && canStand;

        if (_jump && canJump)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
            _jump = false;
        }

        _animator.SetBool(_jumpAnimatorKey, !canJump);
        _animator.SetBool(_crouchAnimatorKey, !_headCollider.enabled);
    }

    public void Jump()
    {
        _jump = true;
    }

    public void SetCrawlTrue()
    {
        _crawl = true;
    }

    public void SetCrawlFalse()
    {
        _crawl = false;
    }

    private void FlipX()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_headChecker.position, _headCheckergRadius);
    }
}
