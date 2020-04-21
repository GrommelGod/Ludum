using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropzoneController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _lifes;

    [SerializeField]
    private AudioSource cashSound;

    [SerializeField]
    private GameObject _gameOverScreen;

    public int _lifePoints = 3;

    private void Update()
    {

        var lives = GameStats.Instance.lives;

        switch (lives)
        {
            case 3:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(true);
                break;
            case 2:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(true);
                _lifes[2].SetActive(false);
                break;
            case 1:
                _lifes[0].SetActive(true);
                _lifes[1].SetActive(false);
                _lifes[2].SetActive(false);
                break;
            case 0:
                _lifes[0].SetActive(false);
                _lifes[1].SetActive(false);
                _lifes[2].SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnTriggerEnter2D(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        var enemy = collision.GetComponent<EnemyController>();


        if (player != null)
        {
            if (player.HasItem)
            {
                player.DeliverItem();
                cashSound.Play();
            }
        }

        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            cashSound.Play();

            if (enemy.Type != Assets.Scripts.Enums.EnemyType.Grandma)
            {
                GameStats.Instance.lives--;
            }
        }

    }

}
