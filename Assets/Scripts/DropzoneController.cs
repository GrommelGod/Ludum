using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropzoneController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _lifes;

    public int _lifePoints = 3;

    private void Update()
    {
        switch(_lifePoints)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        var enemy = collision.GetComponent<EnemyController>();


        if (player != null)
        {
            player.DeliverItem();
        }

        if (enemy != null)
        {
            Destroy(enemy.gameObject);
            _lifePoints--;

            if(_lifePoints == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("You died !");
    }
}
