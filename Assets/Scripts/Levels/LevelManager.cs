using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    private LevelLoader levelcomplete;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;

    //private Scene currentScene;

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
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);        

        //int nextSceneIndex = currentScene.buildIndex + 1;
        int currentSceneIndex = Array.FindIndex(Levels, level => level == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            Debug.Log("Level " + GetLevelStatus(Levels[nextSceneIndex]));
        }
    }

    //Start
    private void Start()
    {
        if (GetLevelStatus("Level1") == LevelStatus.Locked)
            SetLevelStatus("Level1", LevelStatus.Unlocked);     
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
