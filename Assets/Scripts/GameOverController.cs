using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

    //Player dies
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
}
