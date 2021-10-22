using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }

    public void Simulation1()
    {
        SceneManager.LoadScene("Simulation");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
