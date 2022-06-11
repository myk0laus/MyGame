using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private ManaController _manaController;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private int _manaForShot;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _attackAnimatorKey;
    [SerializeField] private GameObject _fireball;
    [SerializeField] private Transform __fireballPos;
    [SerializeField] private float _speed;

    private bool _isAttacking;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _manaController.CurrentMana >= _manaForShot)
        {
            StartAttack();
            _manaController.UseMana(_manaForShot);
        }
    }

    public void StartAttack()
    {
        if (_isAttacking)
            return;
        _isAttacking = true;
        _animator.SetBool(_attackAnimatorKey, true);
    }

    public void Attack()
    {
        GameObject fireball = Instantiate(_fireball, __fireballPos.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
        fireball.GetComponent<SpriteRenderer>().flipX = !playerMover.FaceRight;
        Destroy(fireball, 3f);
    }

    public void EndAttack()
    {
        _isAttacking = false;
        _animator.SetBool(_attackAnimatorKey, false);
    }
}
