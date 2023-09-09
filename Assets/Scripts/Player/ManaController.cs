using System.Collections;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    [SerializeField] private ManaBar _manaBar;
    [SerializeField] private int _maxMana;
    private int _currentMana;

    public int CurrentMana => _currentMana;

    private void Start()
    {
        _currentMana = _maxMana;
        _manaBar.SetMaxMana(_currentMana);
        StartCoroutine(RestoreMana());
    }

    public void UseMana(int manaUsed)
    {
        _currentMana -= manaUsed;
        if (_currentMana < 0)
        {
            _currentMana = 0;
        }
        _manaBar.SetMana(_currentMana);
    }

    public void AddMana(int addMana)
    {
        int missingMana = _maxMana - _currentMana;
        int pointsToAdd = missingMana > addMana ? addMana : missingMana;
        StartCoroutine(AddManaCoroutine(pointsToAdd));
    }

    private IEnumerator AddManaCoroutine(int addMana)
    {
        while (addMana != 0)
        {
            addMana--;
            _currentMana++;
            _manaBar.SetMana(_currentMana);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator RestoreMana()
    {
        while (true)
        {
            if (_currentMana < _maxMana)
            {
                _currentMana += 2;
                _manaBar.SetMana(_currentMana);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
