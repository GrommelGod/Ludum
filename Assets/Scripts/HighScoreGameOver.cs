using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreGameOver : MonoBehaviour
{
    private Text _text;
    
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "We can survive for : " + GameStats.Instance.points + "days ! That's not enough ! =O";
    }
}
