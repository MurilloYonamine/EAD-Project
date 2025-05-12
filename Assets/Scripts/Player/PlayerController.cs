using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed = 10f;
    private Vector2 currentVelocity;
    [SerializeField] private Vector2 moveDirection;

    [SerializeField] private LayerMask interactiveLayer;
    private bool canInteract = false;

    [Header("Mensagens settings")]
    [SerializeField] private TextMeshProUGUI interactionCounterText;
    private int interactionCount = 0;
    private string interactionText; // Aviso prar interagir com a caixa

    [Header("Spirit Evolution")]
    [SerializeField] Slider EvolutionBar;
    [SerializeField] float Point = 0.1f;
    private float CurrentValue;

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
            interactionCounterText.text = $"Interagiu {interactionCount} vezes!";

            CurrentValue += Point;
            EvolutionBar.value = CurrentValue; 
            if(CurrentValue >= 1.0f)
            {
                interactionCounterText.text = $"Parabéns, você ganhou!!";
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (((1 << collision2D.gameObject.layer) & interactiveLayer) != 0)
        {
            Debug.Log("Entrou na range!");
            canInteract = !canInteract;
            interactionCounterText.color = Color.green;
            interactionText = $"Entrou na range!";
            interactionCounterText.text = interactionText;
        }
    }
    private void OnTriggerExit2D(Collider2D collision2D)
    {
        Debug.Log("Saiu na range!");
        canInteract = !canInteract;
        interactionCounterText.color = Color.red;
        interactionText = $"Está longe da range!"; ;
        interactionCounterText.text = interactionText;
    }
}
