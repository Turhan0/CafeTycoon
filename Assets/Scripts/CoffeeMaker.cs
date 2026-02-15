using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public bool playerInRange;
    public GameObject coffeeMakerUIMenu;
    private bool coffeeMakerUIMenuActivated = false;
    private InventoryManager inventoryManager;

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
}
