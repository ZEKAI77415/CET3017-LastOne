using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shopPanel;

    public PlayerAutoAttack playerAttack;
    public PlayerHealth playerHealth;

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
        playerAttack.IncreaseDamage();
        CloseShop();
    }

    public void BuyAttackSpeedUpgrade()
    {
        playerAttack.IncreaseAttackSpeed();
        CloseShop();
    }

    public void BuyHealthUpgrade()
    {
        playerHealth.IncreaseMaxHealth();
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
}