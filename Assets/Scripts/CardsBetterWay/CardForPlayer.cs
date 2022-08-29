using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardForPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private TMP_Text _nameOfCard;
    [SerializeField] private Image _cardSprite;
    [SerializeField] private TMP_Text _changeAbility;
    [SerializeField] private GameObject _backSideOfCard;
    [SerializeField] private CardStorage _cardStorage;
    [SerializeField] private AudioClip _audioClipTakeCard;

    private static int _count;

    public int CountChosed => _count;

    void Start()
    {
        _nameOfCard.text = _cardStorage._storageNameOfCard;
        _cardSprite.sprite = _cardStorage._storageSpriteOfCard;
        _changeAbility.text = _cardStorage._storageChangeAbility;
    }
    private void Update()
    {
        if (_count >= 3)
        {
            GetComponent<Button>().enabled = false;
        }
    }

    public void SetCountChoosedZero()
    {
        _count = 0;
    }

    public void ClickOnCard()
    {
        SoundManager.instance.PlaySound(_audioClipTakeCard);
        _count++;
        _backSideOfCard.SetActive(false);

        switch (_cardStorage._abilities)
        {
            case Abilities.BonusSpeed:
                _nameOfCard.color = Color.green;
                _playerMover._speed += 2;
                break;
            case Abilities.BonusMass:
                _nameOfCard.color = Color.green;
                _playerMover._rigidBody.mass -= 0.1f;
                    break;
            case Abilities.BonusJumpForce:
                _nameOfCard.color = Color.green;
                _playerMover._jumpForce += 70;
                break;
            case Abilities.AntibonusSpeed:
                _playerMover._speed -= 1;
                break;
            case Abilities.AntibonusMass:
                _playerMover._rigidBody.mass += 0.1f;
                break;
            case Abilities.AntibonusJumpForce:
                _playerMover._jumpForce -= 50;
                break;
        }
        GetComponent<Button>().enabled = false;
    }
}
