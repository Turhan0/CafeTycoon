using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public bool playerInRange;
    public GameObject coffeeMakerUIMenu;
    private bool coffeeMakerUIMenuActivated = false;
    private InventoryManager inventoryManager;
    [SerializeField] private Sprite coffeeImage;

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
        if (!coffeeMakerUIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0f;
            coffeeMakerUIMenu.SetActive(true);
            coffeeMakerUIMenuActivated = true;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (coffeeMakerUIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            coffeeMakerUIMenu.SetActive(false);
            coffeeMakerUIMenuActivated = false;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void MakeCoffee()
    {
        int coffee_index = -1;
        int water_index = -1;

        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Coffee Beans")
            {
                coffee_index = i;
                break;
            }
        }
        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Water")
            {
                water_index = i;
                break;
            }
        }

        if(coffee_index != -1 && water_index != -1)
        {
            inventoryManager.RemoveItem(coffee_index);
            inventoryManager.RemoveItem(water_index);
            inventoryManager.AddItem("Coffee", 1, coffeeImage, "A hot cup of coffee to keep you awake.");
            //AudioManager.Instance.PlayCraftingSound();
        }
        else
        {
            //AudioManager.Instance.PlayCraftingFailSound();
            Debug.Log("Not enough ingredients to make coffee.");
        }
    }
}
