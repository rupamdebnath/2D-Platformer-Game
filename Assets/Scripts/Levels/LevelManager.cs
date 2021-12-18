using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

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

    //Start
    private void Start()
    {
        
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
