using Unity.VisualScripting;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] private int health = 15;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private bool isPlayer;
    [SerializeField] private int scoreValue = 100;
    [SerializeField] private bool shouldShake = false;

    private CameraShake cameraShake;
    private ScoreManager scoreManager;
    private LevelManager levelManager;

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        levelManager = FindFirstObjectByType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            TakeDamage(damageDealer.GetDamageAmount());
            damageDealer.Hit();
            PlayHitEffect();
            AudioManager.Instance.PlayDamageSound();

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
            Die();
        }

    }

    private void Die()
    {
        if (isPlayer)
        {
            levelManager.LoadGameOver();
        }
        else
        {
            scoreManager.ModifyScore(scoreValue);
        }
        Destroy(gameObject);
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

    public int GetHealth()
    {
        return health;
    }
}
