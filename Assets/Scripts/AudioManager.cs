using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // shooting sound
    [SerializeField] private AudioClip shootingSFX;
    [SerializeField, Range(0f, 1f)] private float shootingVolume = 1f;

    // taking damage sound
    [SerializeField] private AudioClip damageClip;
    [SerializeField, Range(0f, 1f)] private float damageVolume = 1f;

    public static AudioManager Instance { get; private set; }

    private void SingletonManager()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SingletonManager();
    }

    public void PlayShootingSound()
    {
        PlayAudioClip(shootingSFX, shootingVolume);
    }

    public void PlayDamageSound()
    {
        PlayAudioClip(damageClip, damageVolume);
    }
    private void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip == null) return;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
