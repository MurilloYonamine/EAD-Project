using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed = 10f;
    private Vector2 currentVelocity;
    [SerializeField] private Vector2 moveDirection;

    [SerializeField] private LayerMask interactiveLayer;
    private bool canInteract = false;

    [SerializeField] SpriteRenderer spriteRenderer;
    private int interactionCount = 0;
    private string interactionText;

    private void Update()
    {
        if(rigidBody2D.linearVelocityX < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (rigidBody2D.linearVelocityX > 0f) 
        {
        
            spriteRenderer.flipX = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = moveDirection * moveSpeed;
        rigidBody2D.linearVelocity = Vector2.SmoothDamp(rigidBody2D.linearVelocity, targetVelocity, ref currentVelocity, 0.05f);
        
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started && canInteract)
        {
            interactionCount++;
            EvoluçãoEspiritual.Instance.OnUpgrade();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (((1 << collision2D.gameObject.layer) & interactiveLayer) != 0)
        {
            Debug.Log("Entrou na range!");
            canInteract = !canInteract;
            interactionText = $"Entrou na range!";
        }

        if (collision2D.CompareTag("Enemy"))
        {
            Debug.Log("Entrou em contado");
            EvoluçãoEspiritual.Instance.OnDecrease();
        }
    }
    private void OnTriggerExit2D(Collider2D collision2D)
    {
        Debug.Log("Saiu na range!");
        canInteract = !canInteract;
        interactionText = $"Está longe da range!"; ;
    }
}
