using System.Collections.Generic;
using UnityEngine;

public class CardsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panelOfCards;
    [SerializeField] private Transform _container;
    [SerializeField] private List<GameObject> _cards = new List<GameObject>();
    [SerializeField] private int _maxCards;
    [SerializeField] private Card _card;
    [SerializeField] private GameObject _gameTimer;
    [SerializeField] private GatesOnStart _gates;
 
    void Start()
    {
        _panelOfCards.SetActive(true);
        for (int i = 0; i < _maxCards; i++)
        {
            GameObject someCard = Instantiate(_cards[Random.Range(0, _cards.Count)], _container.position, Quaternion.identity);
            someCard.transform.SetParent(_container);
        }
    }

    private void InactivePanel()
    {
        _panelOfCards.SetActive(false);
    }

    private void Update()
    {
        if(_card.CountChosed >= _maxCards)
        {      
            Invoke(nameof(InactivePanel), 1f);
            _gates.CanMoveUp = true;
            _gameTimer.SetActive(true);
        }       
    }
}
