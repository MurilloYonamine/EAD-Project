using UnityEngine;

public class Perdendo_PEE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Entrou em contado");
            EvoluçãoEspiritual.Instance.OnDecrease();
        }
    }
}
