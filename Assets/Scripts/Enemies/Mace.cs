using UnityEngine;

public class Mace : MonoBehaviour
{
    [SerializeField] private int _dmg;
    [SerializeField] private float _pushPower;
    private float _attackDelay;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HpManager player = collision.collider.GetComponent<HpManager>();
        if(player != null)
        {
            player.TakeDamage(_dmg, _pushPower, transform.position.x);
        }
    }
}
