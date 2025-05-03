using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody2D;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Vector2 moveDirection;
    private void Update() {
        rigidBody2D.linearVelocity = moveDirection * moveSpeed;
    }
    public void Move(InputAction.CallbackContext context) {
        moveDirection = context.ReadValue<Vector2>();
    }
}
