using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _flagAppearKey;
    [SerializeField] private string _flagIdle;

    public bool Finished { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if (player != null)
            _animator.SetBool(_flagAppearKey, true);

        Invoke(nameof(FinishGame), 1f);
    }

    private void FinishGame()
    {
        Finished = true;
        Time.timeScale = 0f;
    }

    public void FlagIdle()
    {
        _animator.SetBool(_flagIdle, true);
    }
}
