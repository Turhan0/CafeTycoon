using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource SFXsource;
    [SerializeField] private AudioClip purchaseSound;
    [SerializeField] private AudioClip purchaseFailSound;
    [SerializeField] private AudioClip discardSound;
    [SerializeField] private AudioClip menuOpenSound;
    [SerializeField] private AudioClip menuCloseSound;
    [SerializeField] private AudioClip footstepSound;
    [SerializeField] private AudioClip doorSound;
    [SerializeField] private AudioClip drinkmakerSound;
    [SerializeField] private AudioClip actionFailSound;
    [SerializeField] private AudioClip buttonClickSound;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayPurchaseSound()
    {
        SFXsource.PlayOneShot(purchaseSound);
    }
    public void PlayPurchaseFailSound()
    {
        SFXsource.PlayOneShot(purchaseFailSound);
    }
    public void PlayDiscardSound()
    {
        SFXsource.PlayOneShot(discardSound);
    }
    public void PlayMenuOpenSound()
    {
        SFXsource.PlayOneShot(menuOpenSound);
    }
    public void PlayMenuCloseSound()
    {
        SFXsource.PlayOneShot(menuCloseSound);
    }
    public void PlayFootstepSound()
    {
        SFXsource.PlayOneShot(footstepSound);
    }

    public void PlayDoorSound()
    {
        SFXsource.PlayOneShot(doorSound);
    }

    public void PlayDrinkmakerSound()
    {
        SFXsource.PlayOneShot(drinkmakerSound);
    }

    public void PlayActionFailSound()
    {
        SFXsource.PlayOneShot(actionFailSound);
    }

    public void PlayButtonClickSound()
    {
        SFXsource.PlayOneShot(buttonClickSound);
    }

}
