using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.lives <= 0 )
        {
            EndGame();
        }
    }
    void EndGame()
    {

        gameEnded = true;
        Debug.Log("Game Over");

    }

}
