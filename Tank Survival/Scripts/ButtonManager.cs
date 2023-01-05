using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        UIManager.instance.gameOver = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
