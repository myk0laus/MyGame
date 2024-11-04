using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private Transform _bloodPos;
    [SerializeField] private GameObject _bloodParticle;
    [SerializeField] private HealthView _hpBar;
    [SerializeField] private int _maxHp;
    [SerializeField] private AudioClip _takeDamakeSound;
    private Animator _animator;
    private PlayerMover playerMover;
    private Rigidbody2D _rb;
    private int _currentHp;

    public int CurrentHp
    {
        get => _currentHp;
        set
        {
            if (value >= _maxHp)
                value = _maxHp;

            _currentHp = value;
            _hpBar.SetHp(_currentHp);
        }
    }

    private void Start()
    {
        playerMover = GetComponent<PlayerMover>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        CurrentHp = _maxHp;
        _hpBar.SetMaxHp(_maxHp);

    }

    public void TakeDamage(int damage, float pushPower = 0, float enemyPosX = 0)
    {
        if (_animator.GetBool(playerMover.HurtAnimatorKey))
        {
            return;
        }

        SoundManager.instance.PlaySound(_takeDamakeSound);
        CurrentHp -= damage;
        Instantiate(_bloodParticle, _bloodPos.position, Quaternion.identity);

        if (_currentHp <= 0)
        {
            gameObject.SetActive(false);
            Invoke(nameof(ReloaderScene), 1f);
        }

        if(pushPower != 0 && Time.time - playerMover.LastHurtTime > 0.5)
        {
            playerMover.LastHurtTime = Time.time;
            int direction = enemyPosX > transform.position.x ? -1 : 1;
            _rb.AddForce(new Vector2(direction * pushPower, pushPower));
            _animator.SetBool(playerMover.HurtAnimatorKey, true);
            
        }
    } 

    public void AddHp(int hpPoints)
    {
        int missingHp = _maxHp - CurrentHp;
        int pointsToAdd = missingHp > hpPoints ? hpPoints : missingHp;
        StartCoroutine(RestoreHp(pointsToAdd));
    }

    private IEnumerator RestoreHp(int pointsToAdd)
    {
        while (pointsToAdd != 0)
        {
            pointsToAdd--;
            CurrentHp++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ReloaderScene()
    {
        SceneManager.LoadScene(0);
    }
}