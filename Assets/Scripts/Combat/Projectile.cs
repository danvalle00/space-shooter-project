using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D projectileRb;

    private void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileRb.linearVelocity = transform.up * speed;
    }

}
