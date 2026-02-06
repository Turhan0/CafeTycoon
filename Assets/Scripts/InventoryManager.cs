using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public static bool menuActivated = false;
    public ItemSlot[] itemSlots;
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
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
        Debug.Log("Added " + quantity + " of " + itemName + " with sprite " + itemSprite.name + " to inventory.");
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }
    
}
