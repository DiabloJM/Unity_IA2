using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenCanvas(GameObject canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseCanvas(GameObject canvas)
    {
        canvas.gameObject.SetActive(false);
    }
}
