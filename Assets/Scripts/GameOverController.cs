using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    //Get Source Button
    public Button restartButton;

    //Awake()
    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
    }

    //Player dies
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("NewScene");
    }
}
