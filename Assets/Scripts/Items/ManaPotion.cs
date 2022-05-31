using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private int _manaPotion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManaController player = collision.GetComponent<ManaController>();
        if(player != null)
        {
            player.AddMana(_manaPotion);
            Destroy(gameObject);
        }
        
    }
}
