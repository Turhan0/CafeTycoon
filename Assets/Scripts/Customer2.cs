using UnityEngine;

public class Customer2 : MonoBehaviour
{
    public bool playerInRange;
    public GameObject npc2UIMenu;
    private bool npc2UIMenuActivated = false;
    private InventoryManager inventoryManager;
    public bool order2Submitted = false;

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
        //Customer2
        if (!npc2UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order2Submitted)
        {
            Time.timeScale = 0f;
            npc2UIMenu.SetActive(true);
            npc2UIMenuActivated = true;
            Cursor.lockState  =  CursorLockMode.None;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (npc2UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order2Submitted)
        {
            Time.timeScale = 1f;
            npc2UIMenu.SetActive(false);
            npc2UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void SubmitOrder2()
    {
        int cake_index = -1;
        int coffee_index = -1;

        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Cake")
            {
                cake_index = i;
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

        if(cake_index != -1 && coffee_index != -1)
        {
            inventoryManager.RemoveItem(cake_index);
            inventoryManager.RemoveItem(coffee_index);
            order2Submitted = true;
            MoneySystem.playerMoney += 3; 
            MoneySystem.instance.UpdateMoneyUI();

            Time.timeScale = 1f;
            npc2UIMenu.SetActive(false);
            npc2UIMenuActivated = false;
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
