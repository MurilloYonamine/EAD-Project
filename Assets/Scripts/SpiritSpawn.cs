using System.Collections;
using UnityEngine;

public class SpiritSpawn : MonoBehaviour
{
    [Header("Spawn Components")]
    [SerializeField] Transform[] Spawner;
    [SerializeField] GameObject[] Spirit;

    [Header("Time Settings")]
    [SerializeField] float TimeToSpawn = 2f;
    [SerializeField] float TimeToStopMusic = 3f;
    [SerializeField] float TimeToMusic = 10f;
    [SerializeField] float TimeToLife = 5f;

    // Para rastrear se um ponto está ocupado
    private bool[] pontoOcupado;

    void Start()
    {
        pontoOcupado = new bool[Spawner.Length];
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToStopMusic);

            if (TimeToStopMusic <= TimeToMusic)
            {
                // Tenta spawnar um espírito em um ponto livre
                int tentativas = 10;
                bool spawnou = false;

                while (!spawnou && tentativas > 0)
                {
                    int indexSpawn = Random.Range(0, Spawner.Length);

                    if (!pontoOcupado[indexSpawn])
                    {
                        int indexSpirit = Random.Range(0, Spirit.Length);
                        GameObject instanciado = Instantiate(Spirit[indexSpirit],Spawner[indexSpawn].position,Spawner[indexSpawn].rotation);
                        pontoOcupado[indexSpawn] = true;//  

                        StartCoroutine(DestruirComDelay(instanciado, indexSpawn));

                        spawnou = true;
                    }

                    tentativas--;
                    if (!spawnou) yield return null; // espera um frame e tenta de novo
                }

                yield return new WaitForSeconds(TimeToSpawn);
            }
        }
    }

    IEnumerator DestruirComDelay(GameObject obj, int spawnIndex)
    {
        yield return new WaitForSeconds(TimeToLife);
        Destroy(obj);
        pontoOcupado[spawnIndex] = false;
    }
}
