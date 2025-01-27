using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 5f;  // Velocidade de movimento do kamikaze
    private Rigidbody rb;  // Referência ao Rigidbody
    private Transform targetPlayer;  // Referência ao transform do Player
    [SerializeField] GameObject explosion;

    [Header("Cooldown")]
    [SerializeField] private float destroyDelay = 1f;  // Tempo de espera antes de destruir o objeto após colisão


    void Start()
    {
        transform.parent = GameObject.FindGameObjectWithTag("Enemies").transform;
        // Obtém a referência do Rigidbody do objeto
        rb = GetComponent<Rigidbody>();

        // Procura o objeto com a tag "Player" e pega sua referência
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            targetPlayer = player.transform;  // Armazena a posição do Player
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com a tag 'Player' encontrado.");
        }
    }

    void FixedUpdate()
    {
        if (targetPlayer != null)
        {
            // Movimenta o kamikaze em direção ao Player utilizando Rigidbody
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calcula a direção em relação ao Player
        Vector3 direction = targetPlayer.position - transform.position;
        direction.Normalize();  // Normaliza o vetor para garantir que o movimento tenha a mesma velocidade em todas as direções

        // Ajusta a velocidade do Rigidbody para mover o kamikaze em direção ao Player
        rb.velocity = direction * moveSpeed;  // Aplicando velocidade no Rigidbody
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto colidido é o Player
        if (other.gameObject.CompareTag("Player"))
        {
            explosion.SetActive(true);
            // Inicia a destruição após a colisão
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private IEnumerator DestroyAfterDelay()
    {
        // Espera o tempo definido antes de destruir o objeto
        yield return new WaitForSeconds(destroyDelay);

        // Destrói o objeto (o próprio kamikaze)
        Destroy(gameObject);
    }
}
