using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private AudioClip _leverActiveSound;

    private SpriteRenderer _spriteRenderer;
    private bool _played = false;

    public event Action LeverTurned;  

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if (player != null && _played == false)
        {
            LeverTurned?.Invoke();
            _played = true;
            SoundManager.instance.PlaySound(_leverActiveSound); 
            _spriteRenderer.sprite = _activeSprite;
        }
    }
}
