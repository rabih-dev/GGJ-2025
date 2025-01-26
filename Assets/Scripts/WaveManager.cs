using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject[] Enemies;
    
    [Header("References")]
    [SerializeField] Transform[] summonPositions;

    
    [Header("Cooldowns")]
    [SerializeField] float cd;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrepareToSummon());
    }

    private IEnumerator PrepareToSummon()
    {
        // Fica em um loop contínuo, mudando a direção após um tempo aleatório
        while (true)
        {
            // Cadencia do tiro
            yield return new WaitForSeconds(cd);

            Summon();
        }
    }

    void Summon()
    {
        int n = Random.Range(0,4);
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if(n != 3) {Instantiate(Enemies[n], summonPositions[Random.Range(0,8)]); }
        else {Instantiate(Enemies[n], player); }
    }
}
