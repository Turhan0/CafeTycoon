using UnityEngine;

public class ShopSlots : MonoBehaviour
{
    private InventoryManager inventoryManager;
    [SerializeField] private Sprite coffeeImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void addCoffeeItem()
    {
        if(MoneySystem.playerMoney >= 2)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Coffee", 1, coffeeImage, "A hot cup of coffee to keep you awake.");
                MoneySystem.playerMoney -= 2; 
                MoneySystem.instance.UpdateMoneyUI();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            Debug.Log("Not enough money to buy coffee.");
        }
    }

}
