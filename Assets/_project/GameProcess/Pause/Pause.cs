using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool IsPaused { get; private set; }
    public GameObject PauseMenu;

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Continue();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
