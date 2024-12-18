using UnityEngine;

public class GatesOnStart : MonoBehaviour
{
    [SerializeField] private Transform _posToGo;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _gatesOpening;
    [SerializeField] CardsPanel _cardsPanel;

    private Vector2 _moveTo;
    private bool _canBeOpened;

    private void OnEnable()
    {
        _cardsPanel.LevelStarted += OpenGates;
    }

    private void Start()
    {
        _moveTo = _posToGo.position;
    }

    private void Update()
    {
        if(_canBeOpened)
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);
    }

    private void OpenGates()
    {
        _canBeOpened = true;
        SoundManager.instance.PlaySound(_gatesOpening);
        _cardsPanel.LevelStarted-= OpenGates;
    }
}
