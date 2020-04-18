using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropzoneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();


        if (player != null)
        {
            player.DeliverItem();
        }
    }
}
