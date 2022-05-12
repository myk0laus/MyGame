using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{

    [SerializeField] private int _hpPoints;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if(player != null)
        {
            Destroy(gameObject);
            Debug.Log($"Added {_hpPoints} hp");
        }
    }
}
