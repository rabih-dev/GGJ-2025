using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject[] Bots;
    
    [Header("References")]
    [SerializeField] Transform[] summonPositions;

    
    [Header("Cooldowns")]
    [SerializeField] float cd;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrepareToFood());
    }

    private IEnumerator PrepareToFood()
    {
        // Fica em um loop contínuo, mudando a direção após um tempo aleatório
        while (true)
        {
            // Cadencia do summon
            yield return new WaitForSeconds(cd);

            SummonFood();
        }
    }

    void SummonFood()
    {
        int n = Random.Range(0,2);
        Instantiate(Bots[n], summonPositions[Random.Range(0,8)]);  
    }
}

