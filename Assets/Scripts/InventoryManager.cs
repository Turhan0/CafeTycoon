using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public static bool menuActivated = false;
    public ItemSlot[] itemSlots;

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
                AudioManager.Instance.PlayMenuOpenSound();
            }

            else if(Input.GetKeyDown(KeyCode.I) && menuActivated)
            {
                Time.timeScale = 1f;
                InventoryMenu.SetActive(false);
                menuActivated = false;
                AudioManager.Instance.PlayMenuCloseSound();
            }
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
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

    public void DiscardAllItems()
    {
        if(itemSlots[0].itemName == null)
        {
            Debug.Log("No items to discard.");
            return;
        }
        else
        {
            for (int i = 0; i < itemSlots.Length; i++)
            {
                itemSlots[i].itemName = null;
                itemSlots[i].quantity = 0;
                itemSlots[i].itemSprite = null;
                itemSlots[i].isFull = false;
                itemSlots[i].itemDescription = null;

                itemSlots[i].quantityText.text = "";
                itemSlots[i].quantityText.enabled = false;
                itemSlots[i].itemImage.sprite = null;
            }
            AudioManager.Instance.PlayDiscardSound();
        }

    }
    
}
