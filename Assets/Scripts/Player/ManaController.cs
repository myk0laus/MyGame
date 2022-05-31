using System.Collections;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    [SerializeField] private ManaBar _manaBar;
    [SerializeField] private int _manaShot;
    [SerializeField] private int _maxMana;
    private int currentMana;

    private void Start()
    {
        currentMana = _maxMana;
        _manaBar.SetMaxMana(currentMana);
        StartCoroutine(RestoreMana());
    }

    private void Update()
    {       
        if (Input.GetKeyDown(KeyCode.E))
            UseMana(_manaShot);
    }

    private void UseMana(int manaUsed)
    {
        currentMana -= manaUsed;
        if (currentMana < 0)
        {
            currentMana = 0;
        }
        _manaBar.SetMana(currentMana);
    }

    public void AddMana(int addMana)
    {
        int missingMana = _maxMana - currentMana;
        int pointsToAdd = missingMana > addMana ? addMana : missingMana;
        StartCoroutine(AddManaCoroutine(pointsToAdd));
    }

    private IEnumerator AddManaCoroutine(int addMana)
    {
        while (addMana != 0)
        {
            addMana--;
            currentMana++;
            _manaBar.SetMana(currentMana);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator RestoreMana()
    {
        while (true)
        {
            if (currentMana < _maxMana)
            {
                currentMana++;
                _manaBar.SetMana(currentMana);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield return null;
            }
        }
    }
}
