using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private int _manaPotion;
    [SerializeField] private AudioClip _pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManaController player = collision.GetComponent<ManaController>();
        if (player != null)
        {
            player.AddMana(_manaPotion);
            SoundManager.instance.PlaySound(_pickUpSound);
            Destroy(gameObject);
        }
    }
}
