using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;
    public static bool isPaused;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(isPaused)
            {
                ResumeButton();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState  =  CursorLockMode.None;
        container.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeButton()
    {
        Cursor.lockState  =  CursorLockMode.Locked;
        container.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsButton()
    {
        
    }

    public void ExitButton()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("");
        SceneManager.LoadSceneAsync(0);
    }



}
