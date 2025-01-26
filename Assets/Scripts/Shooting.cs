using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] float cooldownTime;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        // Procura o objeto com a tag "Player" e pega sua referência
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            StartCoroutine(PrepareToShoot());  // Armazena a posição do Player
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com a tag 'Player' encontrado.");
        }
    }

    private IEnumerator PrepareToShoot()
    {
        // Fica em um loop contínuo, mudando a direção após um tempo aleatório
        while (true)
        {
            // Cadencia do tiro
            yield return new WaitForSeconds(cooldownTime);

            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bullet, this.transform);
    }
}
