using UnityEngine;
using UnityEngine.UI;

public class IdleGame : MonoBehaviour
{
    public GameObject upgrades;
    public Text coinsText;
    public Text clickValueText;
    public double coins;
    public double coinsClickValue;

    public Text coinsPerSec;
    public Text clickUpgrade;
    public Text clickUpgrade2;
    public Text production;

    public double coinsPerSecond;
    public double clickUpgradeCost;
    public int clickUpgradeLevel;

    public double productionUpgradeCost;
    public int productionUpgradeLevel;

    public double clickUpgradeCost2;
    public int clickUpgradeLevel2;

    private void Awake()
    {
        upgrades.gameObject.SetActive(false);
    }


    void Start()
    {
        coinsClickValue = 1;
        clickUpgradeCost = 10;
        productionUpgradeCost = 25;
        clickUpgradeCost2 = 50;
    }

    
    void Update()
    {
        if (coins == 10)
        {
            upgrades.gameObject.SetActive(true);
        }
        coinsPerSecond = productionUpgradeLevel;

        clickValueText.text = "Click\n" + coinsClickValue + " Coins";
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSec.text = coinsPerSecond.ToString("F0") + " coins/s";

        clickUpgrade.text = "Click Upgrade 1\nCost: " + clickUpgradeCost.ToString("F0") + " coins\nPower: +1 Click\nLevel: " + clickUpgradeLevel;
        clickUpgrade2.text = "Click Upgrade 2\nCost: " + clickUpgradeCost2.ToString("F0") + " coins\nPower: +5 Click\nLevel: " + clickUpgradeLevel2;

        production.text = "Production Upgrade 1\nCost: " + productionUpgradeCost.ToString("F0") + " coins\nPower: +1 coins/s\nLevel: " + productionUpgradeLevel;

        coins += coinsPerSecond * Time.deltaTime;
    }

    // Buttons
    public void Click()
    {
        coins += coinsClickValue;
    }

    public void BuyClickUpgrade1()
    {
        if (coins >= clickUpgradeCost)
        {
            clickUpgradeLevel++;
            coins -= clickUpgradeCost;
            clickUpgradeCost *= 1.07;
            coinsClickValue++;
        }
    }
    public void BuyClickUpgrade2()
    {
        if (coins >= clickUpgradeCost2)
        {
            clickUpgradeLevel2++;
            coins -= clickUpgradeCost2;
            clickUpgradeCost2 *= 1.09;
            coinsClickValue += 5;
        }
    }
    public void BuyProductionUpgrade1()
    {
        if (coins >= productionUpgradeCost)
        {
            productionUpgradeLevel++;
            coins -= productionUpgradeCost;
            productionUpgradeCost *= 1.07;
        }
    }


}
