using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EvoluçãoEspiritual : MonoBehaviour {
    public static EvoluçãoEspiritual Instance { get; private set; }

    [SerializeField] private GameObject[] evolucoes;

    [SerializeField]
    private readonly Color[] cores = {
        new Color32(240, 48, 48, 255),  // VermelhoBrilhante
        new Color32(197, 38, 38, 255),  // VermelhoEscuro
        new Color32(155, 39, 42, 255),  // Bordo
        new Color32(78, 63, 131, 255),  // RoxoEscuro
        new Color32(58, 94, 146, 255),  // AzulAcinzentado
        new Color32(47, 104, 161, 255), // AzulMedio
        new Color32(88, 132, 209, 255)  // AzulVibrante
    };

    private int atualEvolucao = 0;

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() {
        if (evolucoes.Length != cores.Length) {
            Debug.LogError($"O array de evoluções deve conter exatamente {cores.Length} elementos.");
            return;
        }

        evolucoes[atualEvolucao].GetComponent<Image>().color = cores[atualEvolucao];

        for (int i = 1; i < evolucoes.Length; i++) {
            evolucoes[i].GetComponent<Image>().color = Color.white;
        }
    }
    public void OnUpgrade() {
        Debug.Log($"Evoluindo para a próxima fase: {atualEvolucao + 1}");
        if (atualEvolucao >= evolucoes.Length - 1) {
            Debug.Log("Evolução máxima alcançada.");
            return;
        }
        atualEvolucao++;
        evolucoes[atualEvolucao].GetComponent<Image>().color = cores[atualEvolucao];
    }
}
