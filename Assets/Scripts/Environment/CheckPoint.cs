using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _flagAppearKey;
    [SerializeField] private string _flagIdle;
    [SerializeField] private AudioClip _finishSound;

    public bool Finished { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if (player != null)
        {
            _animator.SetBool(_flagAppearKey, true);
            SoundManager.instance.PlaySound(_finishSound);
            UnlockLevel();
            Invoke(nameof(FinishGame), 1f);
        }
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
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
