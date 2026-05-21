using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestWaveText;

    private void Start()
    {
        int bestWave = PlayerPrefs.GetInt("BestWave", 0);
        bestWaveText.text = "Best Wave: " + bestWave;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}