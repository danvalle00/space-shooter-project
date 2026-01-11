using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    public int GetDamageAmount()
    {
        return damageAmount;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
