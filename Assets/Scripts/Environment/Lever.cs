using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Lever : MonoBehaviour
{
    [SerializeField] private Sprite _activeSprite;
    [SerializeField] private Gates _gates;
    [SerializeField] private AudioClip _leverActiveSound;

    private SpriteRenderer _spriteRenderer;
    private Sprite _inactiveSprite;
    private int counter = 0;

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
            counter++;
            if (counter > 1) 
            {
                _leverActiveSound = null;
            }
            SoundManager.instance.PlaySound(_leverActiveSound);
            _spriteRenderer.sprite = _activeSprite;
            _gates.Activated = true;
        }
    }

}
