using UnityEngine;

public class Mace : MonoBehaviour
{
    [SerializeField] private int _dmg;
    [SerializeField] private float _pushPower;
    private float _attackDelay;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthContainer player = collision.collider.GetComponent<HealthContainer>();
        if(player != null)
        {
            player.TakeDamage(_dmg, _pushPower, transform.position.x);
        }
    }
}
