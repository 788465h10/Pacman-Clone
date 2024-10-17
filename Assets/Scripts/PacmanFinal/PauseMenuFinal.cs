using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuFinal : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
