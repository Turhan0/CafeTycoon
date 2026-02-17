using UnityEngine;

public class Customer4 : MonoBehaviour
{
public bool playerInRange;
    public GameObject npc4UIMenu;
    private bool npc4UIMenuActivated = false;
    private InventoryManager inventoryManager;
    public bool order4Submitted = false;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        //Customer4
        if (!npc4UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order4Submitted)
        {
            Time.timeScale = 0f;
            npc4UIMenu.SetActive(true);
            npc4UIMenuActivated = true;
            Cursor.lockState  =  CursorLockMode.None;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (npc4UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order4Submitted)
        {
            Time.timeScale = 1f;
            npc4UIMenu.SetActive(false);
            npc4UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void SubmitOrder4()
    {
        int croissant_index = -1;
        int tea_index = -1;

        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Croissant")
            {
                croissant_index = i;
                break;
            }
        }
        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Tea")
            {
                tea_index = i;
                break;
            }
        }

        if(croissant_index != -1 && tea_index != -1)
        {
            inventoryManager.RemoveItem(croissant_index);
            inventoryManager.RemoveItem(tea_index);
            order4Submitted = true;
            MoneySystem.playerMoney += 1.2; 
            MoneySystem.instance.UpdateMoneyUI();

            Time.timeScale = 1f;
            npc4UIMenu.SetActive(false);
            npc4UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            //AudioManager.Instance.PlayDrinkmakerSound();
        }
        else
        {
            AudioManager.Instance.PlayActionFailSound();
            Debug.Log("Not enough items to submit order.");
        }
    }
}
