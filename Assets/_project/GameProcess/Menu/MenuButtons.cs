using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
