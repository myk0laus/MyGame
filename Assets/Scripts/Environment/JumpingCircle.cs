using UnityEngine;

public class JumpingCircle : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _distruptionAnimatorKey;
    [SerializeField] private float _jumpForce;
    [SerializeField] private AudioClip _audioClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(_audioClip);
        PlayerMover player = collision.collider.GetComponent<PlayerMover>();
        if (player != null)
        {
            _animator.SetBool(_distruptionAnimatorKey, true);
            player._rigidBody.velocity = Vector2.up * _jumpForce;
        }
    }

    public void SetDistrubFalse()
    {
        _animator.SetBool(_distruptionAnimatorKey, false);
    }
}
