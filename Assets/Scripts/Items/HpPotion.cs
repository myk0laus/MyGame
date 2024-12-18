using UnityEngine;

public class HpPotion : MonoBehaviour
{
    [SerializeField] private int _hpAmount;
    [SerializeField] private AudioClip _pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthContainer player = collision.GetComponent<HealthContainer>();
        if (player != null)
        {
            player.AddHp(_hpAmount);
            SoundManager.instance.PlaySound(_pickUpSound);
            Destroy(gameObject);
        }
    }
}