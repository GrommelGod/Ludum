using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text textComponent;

    // Update is called once per frame
    void Update()
    {
        string text = "Days left : ";

        float currentScore = GameStats.Instance.points;

        text += currentScore.ToString();

        textComponent.text = text;

    }
}
