using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().SpeedUp();
            GameStats.Instance._powerUp = false;
            Destroy(gameObject);
        }

        if(collision.CompareTag("enemy"))
        {
            GameStats.Instance._powerUp = false;
            Destroy(gameObject);
        }
    }
}
