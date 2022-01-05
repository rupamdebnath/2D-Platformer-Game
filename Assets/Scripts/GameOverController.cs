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
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        SoundManager.Instance.PlayOnce(UISounds.GameOver);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.Instance.PlayOnce(UISounds.ButtonClick);
    }
}
