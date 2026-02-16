using UnityEngine;

public class TeaMaker : MonoBehaviour
{
    public bool playerInRange;
    public GameObject teaMakerUIMenu;
    private bool teaMakerUIMenuActivated = false;
    private InventoryManager inventoryManager;
    [SerializeField] private Sprite teaImage;

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
        if (!teaMakerUIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0f;
            teaMakerUIMenu.SetActive(true);
            teaMakerUIMenuActivated = true;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (teaMakerUIMenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            teaMakerUIMenu.SetActive(false);
            teaMakerUIMenuActivated = false;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }

    public void MakeTea()
    {
        int tea_index = -1;
        int water_index = -1;

        for(int i = 0; i < inventoryManager.itemSlots.Length; i++)
        {
            if(inventoryManager.itemSlots[i].itemName == "Tea Leaves")
            {
                tea_index = i;
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

        if(tea_index != -1 && water_index != -1)
        {
            inventoryManager.RemoveItem(tea_index);
            inventoryManager.RemoveItem(water_index);
            inventoryManager.AddItem("Tea", 1, teaImage, "A hot cup of tea perfect choice for a relaxing break.");
            //AudioManager.Instance.PlayMakeSound();
        }
        else
        {
            //AudioManager.Instance.PlayMakeFailSound();
            Debug.Log("Not enough ingredients to make tea.");
        }
    }
}
