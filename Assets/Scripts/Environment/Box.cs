using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.TryGetComponent(out Fireball fireball))
        {
            Destroy(gameObject);
        }
    }
}
