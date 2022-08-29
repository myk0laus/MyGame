using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private PlayerMover player;
    [SerializeField] private GameObject _rubashka;
    [SerializeField] private bool _antiBonusMass;
    [SerializeField] private bool _antiBonusSpeed;
    [SerializeField] private bool _antiBonusJump;
    [SerializeField] private bool _bonusMass;
    [SerializeField] private bool _bonusSpeed;
    [SerializeField] private bool _bonusJump;

    private static int _count;

    public int CountChosed => _count;

    public void SetCountChoosedZero()
    {
        _count = 0;
    }

    public void CkickOnCard()
    {
        _count++;

        _rubashka.SetActive(false);
        if (_antiBonusMass)
        {
            player._rigidBody.mass += 0.1f;
        }

        if (_antiBonusSpeed)
        {
            player._speed -= 0.2f;
        }

        if (_antiBonusJump)
        {
            player.JumpForce -= 50;
        }

        if (_bonusMass)
        {
            player._rigidBody.mass -= 0.1f;
        }

        if (_bonusSpeed)
        {
            player._speed += 0.2f;
        }

        if (_bonusJump)
        {
            player.JumpForce += 50;
        }

        //Destroy(gameObject, 1f);
        GetComponent<Button>().enabled = false;
    }
}
