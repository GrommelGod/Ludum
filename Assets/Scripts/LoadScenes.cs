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

    [SerializeField]
    private GameObject _gameOverScreen;
    
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
        Time.timeScale = 1;
        GameStats.Instance.Refresh();

        GameEvents.OnGameOver += GameEvents_OnGameOver;

        SceneManager.LoadScene("SampleScene");
    }

    private void GameEvents_OnGameOver(object sender, System.EventArgs e)
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameoverScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
