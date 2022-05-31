using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyChest : MonoBehaviour
{
    [SerializeField] private Sprite _openedChest;
    [SerializeField] private int _money;
 
    public bool Activated { private get; set; }
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Activated)
            return;

        PlayerMover player = collision.GetComponent<PlayerMover>();
        if(player != null)
        {
            _spriteRenderer.sprite = _openedChest;
            //player.CoinsAmount += _money;
            _money -= _money;
        }
    }
}
 