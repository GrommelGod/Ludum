using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        Debug.Log("lol");
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
