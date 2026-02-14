using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    public static bool shopUImenuActivated = false;
    public GameObject shopUIMenu;
    public bool playerInRange;

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
        if (!shopUImenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0f;
            shopUIMenu.SetActive(true);
            shopUImenuActivated = true;
            AudioManager.Instance.PlayMenuOpenSound();
        }
        else if (shopUImenuActivated && playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            shopUIMenu.SetActive(false);
            shopUImenuActivated = false;
            AudioManager.Instance.PlayMenuCloseSound();
        }
    }


}
