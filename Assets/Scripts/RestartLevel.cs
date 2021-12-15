using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public GameOverController gameOverController;
    //Level Over on Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Debug.Log("Player is Dead");
            //Debug.Log("Restarting Level..........");

            gameOverController.PlayerDied();            
        }
    }
}
