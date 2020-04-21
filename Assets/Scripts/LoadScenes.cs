using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Models;

public class LoadScenes : MonoBehaviour
{
    [SerializeField]
    private Image _tutorial;
    [SerializeField]
    private GameObject _button;

    public void Tutorial()
    {
        if (_tutorial != null)
        {
            _tutorial.enabled = true;
            _button.SetActive(true);
        }
    }

    public void StartScene()
    {
        GameStats.Instance.Refresh();

        GameEvents.OnGameOver += GameEvents_OnGameOver;

        SceneManager.LoadScene("SampleScene");
    }

    private void GameEvents_OnGameOver(object sender, System.EventArgs e)
    {
        SceneManager.LoadScene("GameoverScene");
    }

    public void RestartGame()
    {
        Debug.Log("lol");
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
