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

}
