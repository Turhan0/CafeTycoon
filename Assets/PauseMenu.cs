using UnityEngine;

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
        //UnityEngine.SceneManagement.SceneManager.LoadScene("");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }



}
