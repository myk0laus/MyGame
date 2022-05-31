using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if(player != null)
        {
            player.CanClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMover player = collision.GetComponent<PlayerMover>();
        if(player != null)
        {
            player.CanClimb = false;
        }
    }
}