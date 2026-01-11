using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] private int health = 15;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            TakeDamage(damageDealer.GetDamageAmount());
            damageDealer.Hit();
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
}
