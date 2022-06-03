using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
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
    //[SerializeField] private string _attackAnimatorKey;

    //[Header("Attack")]
    //[SerializeField] private GameObject _fireball;
    //[SerializeField] private Transform _fireballPos;
    //[SerializeField] private float _fireballSpeed;

    private float _horizontalDirection;
    private float _verticaDirection;
    private bool _jump;
    private bool _crawl;
    //private bool _isAttacking;

    public bool FaceRight => _faceRight;
    public bool CanClimb { private get; set; }

    void Start()
    {
        
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw("Horizontal");
        _verticaDirection = Input.GetAxisRaw("Vertical");

        _animator.SetFloat(_runAnimatorKey, Mathf.Abs(_horizontalDirection));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
        }

        if (_horizontalDirection < 0 && _faceRight)
        {
            FlipX();
        }
        else if (_horizontalDirection > 0 && !_faceRight)
        {
            FlipX();
        }

        _crawl = Input.GetKey(KeyCode.LeftControl);

        //if (Input.GetKey(KeyCode.E))
        //{
        //    StartAttack();

        //}
    }

    private void FixedUpdate()
    {

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

        bool canJump = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        bool canStand = !Physics2D.OverlapCircle(_headChecker.position, _headCheckergRadius, _whatIsCell);

        _headCollider.enabled = !_crawl && canStand;

        if (_jump && canJump)
        {
            _rigidBody.AddForce(Vector2.up * _jumpForce);
            _jump = false;
        }

        _animator.SetBool(_jumpAnimatorKey, !canJump);
        _animator.SetBool(_crouchAnimatorKey, !_headCollider.enabled);
    }

    //public void StartAttack()
    //{
    //    if (_isAttacking)
    //        return;
    //    _isAttacking = true;
    //    _animator.SetBool(_attackAnimatorKey, true);
    //}

    //private void Attack()
    //{
    //    GameObject fireball = Instantiate(_fireball, _fireballPos.position, Quaternion.identity);
    //    fireball.GetComponent<Rigidbody2D>().velocity = transform.right * _fireballSpeed;
    //    fireball.GetComponent<SpriteRenderer>().flipX = !_faceRight;
    //    Destroy(fireball, 3f);
    //}

    //private void EndAttack()
    //{
    //    _isAttacking = false;
    //    _animator.SetBool(_attackAnimatorKey, false);
    //}

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
