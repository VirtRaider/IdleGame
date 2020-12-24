using UnityEngine;
using UnityEngine.UI;

public class IdleGame : MonoBehaviour
{
    public GameObject upgrades;
    public GameObject upgrades2;
    public Text coinsText;
    public Text clickValueText;
    public double coins;
    public double coinsClickValue;

    public Text coinsPerSec;
    public Text clickUpgrade;
    public Text clickUpgrade2;
    public Text production;
    public Text production2;

    public double coinsPerSecond;
    public double clickUpgradeCost;
    public int clickUpgradeLevel;

    public double clickUpgradeCost2;
    public int clickUpgradeLevel2;

    public double productionUpgradeCost;
    public int productionUpgradeLevel;

    public double productionUpgradeCost2;
    public double productionUpgradeCost2Power;
    public int productionUpgradeLevel2;


    private void Awake()
    {
        upgrades.gameObject.SetActive(false);
        upgrades2.gameObject.SetActive(false);
    }


    void Start()
    {
        coinsClickValue = 1;
        clickUpgradeCost = 30;
        productionUpgradeCost = 30;
        clickUpgradeCost2 = 150;
        productionUpgradeCost2 = 150;
        productionUpgradeCost2Power = 5;

    }

    
    void Update()
    {
        if (coins >= 30)
        {
            upgrades.gameObject.SetActive(true);
        }
        if (coins >= 150)
        {
            upgrades2.gameObject.SetActive(true);
        }
        coinsPerSecond = productionUpgradeLevel + (productionUpgradeCost2Power * productionUpgradeLevel2);

        clickValueText.text = "Click\n" + coinsClickValue + " Coins";
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSec.text = coinsPerSecond.ToString("F0") + " coins/s";

        clickUpgrade.text = "Click Upgrade 1\nCost: " + clickUpgradeCost.ToString("F0") + " coins\nPower: +1 Click\nLevel: " + clickUpgradeLevel;
        clickUpgrade2.text = "Click Upgrade 2\nCost: " + clickUpgradeCost2.ToString("F0") + " coins\nPower: +5 Click\nLevel: " + clickUpgradeLevel2;

        production.text = "Production Upgrade 1\nCost: " + productionUpgradeCost.ToString("F0") + " coins\nPower: +1 coins/s\nLevel: " + productionUpgradeLevel;
        production2.text = "Production Upgrade 2\nCost: " + productionUpgradeCost2.ToString("F0") + " coins\nPower: +"+ productionUpgradeCost2Power + " coins/s\nLevel: " + productionUpgradeLevel2;

        coins += coinsPerSecond; //* Time.deltaTime;
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
    public void BuyProductionUpgrade2()
    {
        if (coins >= productionUpgradeCost2)
        {
            productionUpgradeLevel2++;
            coins -= productionUpgradeCost2;
            productionUpgradeCost2 *= 1.07;
        }
    }


}
