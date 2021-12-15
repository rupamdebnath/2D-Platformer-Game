using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitLevel : MonoBehaviour
{
    public Button quitbutton;
    void Awake()
    {
        quitbutton.onClick.AddListener(QuitToLobby);
    }

    private void QuitToLobby()
    {
        SceneManager.LoadScene(0);
       //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));

        //Application.LoadLevel(""Lobby");

    }
}
