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
        AudioManager.Instance.PlayButtonClickSound();
        Cursor.lockState  =  CursorLockMode.None;
        container.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeButton()
    {
        AudioManager.Instance.PlayButtonClickSound();
        Cursor.lockState  =  CursorLockMode.Locked;
        container.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsButton()
    {
        AudioManager.Instance.PlayButtonClickSound();
    }

    public void SaveButton()
    {
        AudioManager.Instance.PlayButtonClickSound();
        // SaveController saveController = GameObject.FindObjectOfType<SaveController>();
        // if(saveController != null)
        // {
        //     saveController.SaveGame(new SaveData());
        // }
    }

    public void ExitButton()
    {
        AudioManager.Instance.PlayButtonClickSound();
        container.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("");
        SceneManager.LoadSceneAsync(0);
    }



}
