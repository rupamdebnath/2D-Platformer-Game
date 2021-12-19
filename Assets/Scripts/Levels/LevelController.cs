using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public GameObject levelComplete;
    //Level Over on Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished by the player");
            Debug.Log("Run Next Level..........");
            LevelManager.Instance.MarkLevelComplete();
            levelComplete.SetActive(true);
        }
    }
}
