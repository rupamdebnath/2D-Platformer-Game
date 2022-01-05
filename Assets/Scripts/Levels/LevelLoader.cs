using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private LevelStatus levelStatus;

    //public GameObject LevelComplete;
    //Awake
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Debug.Log("Level name:" + LevelName); 
        levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.PlayOnce(UISounds.LockedLevel);
                Debug.Log("Can't play this level Until unlocked");
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.PlayOnce(UISounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.PlayOnce(UISounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
        
    }
}
