using UnityEngine;

public class Customer1 : MonoBehaviour
{
    public bool playerInRange;
    public GameObject npc1UIMenu;
    private bool npc1UIMenuActivated = false;
    private InventoryManager inventoryManager;
    public bool order1Submitted = false;
    public GameObject exit; // Example target position

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
        //Customer1
        if (!npc1UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order1Submitted)
        {
            Time.timeScale = 0f;
            npc1UIMenu.SetActive(true);
            npc1UIMenuActivated = true;
            Cursor.lockState  =  CursorLockMode.None;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (npc1UIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E) && !order1Submitted)
        {
            Time.timeScale = 1f;
            npc1UIMenu.SetActive(false);
            npc1UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void SubmitOrder1()
    {
        int cake_index = -1;
        int tea_index = -1;

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
            if(inventoryManager.itemSlots[i].itemName == "Tea")
            {
                tea_index = i;
                break;
            }
        }

        if(cake_index != -1 && tea_index != -1)
        {
            inventoryManager.RemoveItem(cake_index);
            inventoryManager.RemoveItem(tea_index);
            order1Submitted = true;
            MoneySystem.playerMoney += 2.3; 
            MoneySystem.instance.UpdateMoneyUI();

            Time.timeScale = 1f;
            npc1UIMenu.SetActive(false);
            npc1UIMenuActivated = false;
            Cursor.lockState  =  CursorLockMode.Locked;
            //AudioManager.Instance.PlayDrinkmakerSound();
        }
        else
        {
            AudioManager.Instance.PlayActionFailSound();
            Debug.Log("Not enough items to submit order.");
        }

        Vector3 targetPosition = exit.GetComponent<Transform>().position; // Example target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 2f * Time.deltaTime);
        Destroy(gameObject, 5f); // Destroy the customer after 3 seconds to allow time for them to move towards the exit
    }
}
