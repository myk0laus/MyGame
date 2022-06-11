using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _resetTime;
    [SerializeField] private int _damage;
    private float lifetime;
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float moveSpeed = _speed * Time.deltaTime;
        transform.Translate(moveSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > _resetTime)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HpManager player = collision.GetComponent<HpManager>();
        if (player != null)
        {
            player.TakeDamage(_damage);  
        }
        gameObject.SetActive(false);
    }
}
