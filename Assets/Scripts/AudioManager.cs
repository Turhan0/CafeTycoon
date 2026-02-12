using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource SFXsource;
    [SerializeField] private AudioClip purchaseSound;
    [SerializeField] private AudioClip purchaseFailSound;


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

}
