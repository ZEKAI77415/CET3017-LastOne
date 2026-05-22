using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip shootClip;
    public AudioClip coinPickupClip;
    public AudioClip buttonClickClip;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayShoot()
    {
        PlaySound(shootClip);
    }

    public void PlayCoinPickup()
    {
        PlaySound(coinPickupClip);
    }

    public void PlayButtonClick()
    {
        PlaySound(buttonClickClip);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}