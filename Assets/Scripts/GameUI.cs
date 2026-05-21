using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public WaveManager waveManager;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI waveText;

    private void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = "HP: " + playerHealth.CurrentHealth;
        }

        if (waveManager != null)
        {
            waveText.text = "Wave: " + waveManager.currentWave;
        }
    }
}