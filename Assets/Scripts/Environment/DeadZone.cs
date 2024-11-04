using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform _posAffterDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();

        if (player != null)       
            player.transform.position = _posAffterDead.position;      
    } 
}