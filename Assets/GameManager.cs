using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public void GoToMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("game");
    }
}
