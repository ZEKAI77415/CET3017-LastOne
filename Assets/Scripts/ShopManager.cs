using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;

    public PlayerAutoAttack playerAttack;
    public PlayerHealth playerHealth;
    public PlayerCurrency playerCurrency;

    public int damageCost = 5;
    public int attackSpeedCost = 5;
    public int healthCost = 5;

    private WaveManager waveManager;

    private void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();
        shopPanel.SetActive(false);
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BuyDamageUpgrade()
    {
        if (playerCurrency.SpendGold(damageCost))
        {
            playerAttack.IncreaseDamage();
            CloseShop();
        }
    }

    public void BuyAttackSpeedUpgrade()
    {
        if (playerCurrency.SpendGold(attackSpeedCost))
        {
            playerAttack.IncreaseAttackSpeed();
            CloseShop();
        }
    }

    public void BuyHealthUpgrade()
    {
        if (playerCurrency.SpendGold(healthCost))
        {
            playerHealth.IncreaseMaxHealth();
            CloseShop();
        }
    }

    private void CloseShop()
    {
        shopPanel.SetActive(false);
        Time.timeScale = 1f;

        if (waveManager != null)
        {
            waveManager.StartNextWaveFromShop();
        }
    }
    public void SkipUpgrade()
    {
        CloseShop();
    }
}