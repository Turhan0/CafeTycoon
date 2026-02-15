using UnityEngine;

public class ShopSlots : MonoBehaviour
{
    private InventoryManager inventoryManager;
    [SerializeField] private Sprite coffeeImage;
    [SerializeField] private Sprite teaImage;
    [SerializeField] private Sprite croissantImage;
    [SerializeField] private Sprite cakeImage;
    [SerializeField] private Sprite coffeeBeansImage;
    [SerializeField] private Sprite teaLeavesImage;
    [SerializeField] private Sprite waterImage;
    
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
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy coffee.");
        }
    }

    public void addTeaItem()
    {
        if(MoneySystem.playerMoney >= 1)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Tea", 1, teaImage, "A hot cup of tea. Perfect choice for a relaxing break.");
                MoneySystem.playerMoney -= 1; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy tea.");
        }
    }

    public void addCroissantItem()
    {
        if(MoneySystem.playerMoney >= 0.5)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Croissant", 1, croissantImage, "A warm and flaky croissant. Perfect for a morning treat.");
                MoneySystem.playerMoney -= 0.5; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy croissant.");
        }
    }

    public void addCakeItem()
    {
        if(MoneySystem.playerMoney >= 1.5)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Cake", 1, cakeImage, "A delicious cake. Perfect for a sweet treat.");
                MoneySystem.playerMoney -= 1.5; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy cake.");
        }
    }

    public void addCoffeeBeansItem()
    {
        if(MoneySystem.playerMoney >= 0.4)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Coffee Beans", 1, coffeeBeansImage, "Freshly roasted coffee beans. Perfect for brewing your own coffee.");
                MoneySystem.playerMoney -= 0.4; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy coffee beans.");
        }
    }

    public void addTeaLeavesItem()
    {
        if(MoneySystem.playerMoney >= 0.2)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Tea Leaves", 1, teaLeavesImage, "Freshly picked tea leaves. Perfect for brewing your own tea.");
                MoneySystem.playerMoney -= 0.2; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy tea leaves.");
        }
    }

    public void addWaterItem()
    {
        if(MoneySystem.playerMoney >= 0.2)
        {    
            if(!inventoryManager.itemSlots[19].isFull)
            {
                inventoryManager.AddItem("Water", 1, waterImage, "A bottle of water. Perfect for hydration.");
                MoneySystem.playerMoney -= 0.2; 
                MoneySystem.instance.UpdateMoneyUI();
                AudioManager.Instance.PlayPurchaseSound();
            }
            else
            {
             Debug.Log("Inventory is full. Cannot add more items.");
            }
        }
        else
        {
            AudioManager.Instance.PlayPurchaseFailSound();
            Debug.Log("Not enough money to buy water.");
        }
    }

}
