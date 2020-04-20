using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePhysics : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-5 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shelves"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
