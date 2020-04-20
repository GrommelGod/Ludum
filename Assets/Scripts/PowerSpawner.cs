using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _spawns;
    [SerializeField]
    private GameObject _steroid;

    private int _timer = 0;
    private int _timerMax;

    private void Start()
    {
        RandomTimerMax();
    }

    private void Update()
    {
        Debug.Log("Timer : " + _timer);

        if (!GameStats.Instance._powerUp)
        {
            _timer++;

            if (_timer > _timerMax)
            {
                GameObject.Instantiate(_steroid, _spawns[Random.Range(0, _spawns.Length)].transform.position, _spawns[0].transform.rotation);
                _timer = 0;
                GameStats.Instance._powerUp = true;
                RandomTimerMax();
            }
        }
    }

    private void RandomTimerMax()
    {
        _timerMax = Random.Range(600, 1001);
    }
}
