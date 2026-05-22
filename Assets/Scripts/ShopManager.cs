using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;

    public PlayerAutoAttack playerAttack;
    public PlayerHealth playerHealth;
    public PlayerCurrency playerCurrency;

    public TextMeshProUGUI playerStatsText;

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
        UpdateStatsText();
    }

    public void BuyDamageUpgrade()
    {
        if (playerCurrency.SpendGold(damageCost))
        {
            playerAttack.IncreaseDamage();
            UpdateStatsText();
        }
    }

    public void BuyAttackSpeedUpgrade()
    {
        if (playerCurrency.SpendGold(attackSpeedCost))
        {
            playerAttack.IncreaseAttackSpeed();
            UpdateStatsText();
        }
    }

    public void BuyHealthUpgrade()
    {
        if (playerCurrency.SpendGold(healthCost))
        {
            playerHealth.IncreaseMaxHealth();
            UpdateStatsText();
        }
    }

    public void StartNextWave()
    {
        CloseShop();
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

    private void UpdateStatsText()
    {
        if (playerStatsText == null) return;

        playerStatsText.text =
            "Player Stats\n\n" +
            "Damage: " + playerAttack.CurrentDamage + "\n" +
            "Attack Speed: " + playerAttack.AttacksPerSecond.ToString("F2") + "/s\n" +
            "Max HP: " + playerHealth.maxHealth + "\n" +
            "Gold: " + playerCurrency.gold;
    }
}