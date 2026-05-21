using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerCurrency playerCurrency;
    public WaveManager waveManager;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI goldText;

    private void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.CurrentHealth;
        }

        if (playerCurrency != null)
        {
            goldText.text = "Gold: " + playerCurrency.gold;
        }

        if (waveManager != null)
        {
            waveText.text = "Wave: " + waveManager.currentWave;
        }
    }
}