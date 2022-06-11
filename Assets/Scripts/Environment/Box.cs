using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fireball _fireball = collision.collider.GetComponent<Fireball>();

        if(_fireball != null)
        {
            Destroy(gameObject);
        }
    }
}
