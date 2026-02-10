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
        //Sprite coffeeImage = Resources.Load<Sprite>("Assets/Sprites/Coffee_Mug_0");
        inventoryManager.AddItem("Coffee", 1, coffeeImage, "A hot cup of coffee to keep you awake.");
    }

     

}
