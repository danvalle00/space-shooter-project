using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Shooter))]
public class PlayerShoot : MonoBehaviour
{
    private InputAction fireAction;
    private Shooter playerShooter;

    private void Start()
    {
        fireAction = InputSystem.actions.FindAction("Fire");
        playerShooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        FireProjectile();
    }
    private void FireProjectile()
    {
        playerShooter.IsFiring = fireAction.IsPressed();
    }

}
