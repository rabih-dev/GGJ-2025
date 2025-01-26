using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject[] Enemies;
    
    [Header("References")]
    [SerializeField] Transform[] summonPositions;
    [SerializeField] bool HardMode;
    
    [Header("Cooldowns")]
    [SerializeField] float cd;
    [SerializeField] float timeForHardmode;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PrepareToSummon());
        StartCoroutine(MakeGameHarder());
        StartCoroutine(ActiveHardmode());
    }

    IEnumerator MakeGameHarder()
    {
        yield return new WaitForSeconds(90);

        cd = cd - (0.2f*cd);        
    }

    
    IEnumerator ActiveHardmode()
    {
        yield return new WaitForSeconds(timeForHardmode);

        HardMode = true;        
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
        if(!HardMode)
        {
            int n = Random.Range(0,4);
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            if(n != 3) {Instantiate(Enemies[n], summonPositions[Random.Range(0,8)]); }
            else {Instantiate(Enemies[n], player); }
        }
        else 
        {
            int x = Random.Range(0,11);
            if (x > 3)
            {
                int n = Random.Range(3,7);
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                if(n != 3) {Instantiate(Enemies[n], summonPositions[Random.Range(0,8)]); }
                else 
                {
                    // Get the player's current position
                    Transform playerPos = player.transform;

                    // Reset the player's rotation to the identity quaternion
                    playerPos.rotation = Quaternion.identity;

                    // Instantiate the enemy at the player's position and rotation
                    Instantiate(Enemies[n], playerPos.position, playerPos.rotation);
                }
            }
            else 
            {
                int n = Random.Range(0,4);
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                if(n != 3) {Instantiate(Enemies[n], summonPositions[Random.Range(0,8)]); }
                else 
                {
                    // Get the player's current position
                    Transform playerPos = player.transform;

                    // Reset the player's rotation to the identity quaternion
                    playerPos.rotation = Quaternion.identity;

                    // Instantiate the enemy at the player's position and rotation
                    Instantiate(Enemies[n], playerPos.position, playerPos.rotation);
                }
            }
        }
    }
}
