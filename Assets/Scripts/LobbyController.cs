using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    public Button buttonPlay;
    public GameObject LevelSelection;
    // Awake
    void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SoundManager.Instance.PlayOnce(UISounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
}
