using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] private int health = 15;
    [SerializeField] private ParticleSystem hitEffect;

    CameraShake cameraShake;
    [SerializeField] private bool shouldShake = false;

    private AudioManager audioManager;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            TakeDamage(damageDealer.GetDamageAmount());
            PlayHitEffect();
            audioManager.PlayDamageSound();
            damageDealer.Hit();

            if (shouldShake && cameraShake != null)
            {
                cameraShake.PlayShake();
            }

        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void PlayHitEffect()
    {
        if (hitEffect == null)
        {
            return;
        }
        ParticleSystem effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
    }
}
