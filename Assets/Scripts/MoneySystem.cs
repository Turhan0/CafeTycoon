using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI moneyText;
    static public double playerMoney = 10000.0;
    static public MoneySystem instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateMoneyUI();
    }
    public void UpdateMoneyUI()
    {
        moneyText.text = "$" + playerMoney.ToString();
    }


}
