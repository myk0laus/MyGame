using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HpManager : MonoBehaviour
{
    [SerializeField] private Transform _bloodPos;
    [SerializeField] private GameObject _bloodParticle;
    [SerializeField] private HpBar _hpBar;
    [SerializeField] private int _maxHp;
    [SerializeField] private AudioClip _takeDamakeSound;
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
        CurrentHp = _maxHp;
        _hpBar.SetMaxHp(_maxHp);

    }

    public void TakeDamage(int damage, float pushPower = 0, float enemyPosX = 0)
    {
        SoundManager.instance.PlaySound(_takeDamakeSound);
        CurrentHp -= damage;
        Instantiate(_bloodParticle, _bloodPos.position, Quaternion.identity);
        if (_currentHp <= 0)
        {
            gameObject.SetActive(false);
            Invoke(nameof(ReloaderScene), 1f);
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
