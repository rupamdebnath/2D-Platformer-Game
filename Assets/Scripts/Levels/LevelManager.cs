using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private Scene currentScene;

    //Awake
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkLevelComplete()
    {
        //Get current scene and mark it as complete
        currentScene = SceneManager.GetActiveScene();
        Debug.Log("Status of scene before completion" + currentScene.name + " is " + GetLevelStatus(currentScene.name));

        SetLevelStatus(currentScene.name, LevelStatus.Completed);
        Debug.Log("Status of scene after completion" + currentScene.name + " is " + GetLevelStatus(currentScene.name));
    }

    //Start
    private void Start()
    {
        if (GetLevelStatus("Level1") == LevelStatus.Locked)
            SetLevelStatus("Level1", LevelStatus.Unlocked);       
        if (GetLevelStatus("Lobby") == LevelStatus.Locked)
            SetLevelStatus("Lobby", LevelStatus.Unlocked);
    }

    public LevelStatus GetLevelStatus(string level)
    {
        return (LevelStatus) PlayerPrefs.GetInt(level, 0);
    }

    public void SetLevelStatus(string level, LevelStatus levelstatus)
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
    }
}
