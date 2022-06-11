using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform _posAffterDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();

        if (player != null)
        {
            player._rigidBody.position = _posAffterDead.position;
        }
    }
}
