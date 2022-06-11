using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Gates _gates;

    private SpriteRenderer _spriteRenderer;
    private Sprite _inactiveSprite;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inactiveSprite = _spriteRenderer.sprite;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if (player != null)
        {
            _spriteRenderer.sprite = _activeSprite;
            _gates.Activated = true;
        }
    }

}
