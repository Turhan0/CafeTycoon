using UnityEngine;

public class Customer3 : MonoBehaviour
{
public bool playerInRange;
    public GameObject npc3UIMenu;
    private bool npc3UIMenuActivated = false;
    private InventoryManager inventoryManager;
    public bool order3Submitted = false;

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
        //Customer3
        if (!npc3UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order3Submitted)
        {
            Time.timeScale = 0f;
            npc3UIMenu.SetActive(true);
            npc3UIMenuActivated = true;
            Cursor.lockState  =  CursorLockMode.None;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (npc3UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order3Submitted)
        {
            Time.timeScale = 1f;
            npc3UIMenu.SetActive(false);
            npc3UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void SubmitOrder3()
    {
        int croissant_index = -1;
        int coffee_index = -1;

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
            if(inventoryManager.itemSlots[i].itemName == "Coffee")
            {
                coffee_index = i;
                break;
            }
        }

        if(croissant_index != -1 && coffee_index != -1)
        {
            inventoryManager.RemoveItem(croissant_index);
            inventoryManager.RemoveItem(coffee_index);
            order3Submitted = true;
            MoneySystem.playerMoney += 2; 
            MoneySystem.instance.UpdateMoneyUI();

            Time.timeScale = 1f;
            npc3UIMenu.SetActive(false);
            npc3UIMenuActivated = false;
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
