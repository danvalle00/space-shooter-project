using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private InputAction playerInput;
    private Vector3 movementVector;

    // player boundaries
    private Vector2 minBounds;
    private Vector2 maxBounds;
    // da pra usar só 1 variavel pq eh tudo 1 mas enfim
    [SerializeField] private float leftPadding;
    [SerializeField] private float rightPadding;
    [SerializeField] private float topPadding;
    [SerializeField] private float bottomPadding;

    private void Start()
    {
        BoundsInit();
        playerInput = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void BoundsInit()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new(1, 1));
    }


    private void PlayerMovement()
    {
        movementVector = playerInput.ReadValue<Vector2>();
        Vector3 newPos = transform.position + movementVector * Time.deltaTime * moveSpeed;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomPadding, maxBounds.y - topPadding);

        transform.position = newPos;
    }

}
