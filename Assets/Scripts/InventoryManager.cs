using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public static bool menuActivated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused)
        {
          
        
            if(Input.GetKeyDown(KeyCode.I) && !menuActivated)
            {
                Time.timeScale = 0f;
                InventoryMenu.SetActive(true);
                menuActivated = true;
            }

            else if(Input.GetKeyDown(KeyCode.I) && menuActivated)
            {
                Time.timeScale = 1f;
                InventoryMenu.SetActive(false);
                menuActivated = false;
            }
        }
        else
        {
            
        }
    }
}
