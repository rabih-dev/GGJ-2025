using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShotBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 5f;  // Velocidade do movimento
    [SerializeField] private float targetDistanceX = 3f;  // Distância alvo no eixo X
    private Rigidbody rb;  // Referência ao Rigidbody
    private Transform targetPlayer;  // Referência ao Player

    void Start()
    {
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
            // Atualiza a posição do StraightShot para seguir o Player na linha Z e ajustar a posição no eixo X
            MoveAlongZAndX();
        }
    }

    private void MoveAlongZAndX()
    {
        // Mantém a mesma posição Z do Player
        float targetZ = targetPlayer.position.z;
        
        // Calcula a posição desejada no eixo X, mantendo a distância alvo (targetDistanceX)
        float distanceToPlayerX = targetPlayer.position.x - transform.position.x;

        // A diferença no eixo X será usada para determinar o movimento
        float moveDirectionX = 0f;

        // Se a distância no eixo X for maior que a distância alvo, o StraightShot deve avançar
        if (Mathf.Abs(distanceToPlayerX) > targetDistanceX)
        {
            moveDirectionX = Mathf.Sign(distanceToPlayerX) * moveSpeed;
        }
        // Caso contrário, ele deve recuar se o jogador estiver mais perto que a distância alvo
        else if (Mathf.Abs(distanceToPlayerX) < targetDistanceX)
        {
            moveDirectionX = -Mathf.Sign(distanceToPlayerX) * moveSpeed;
        }

        // Aplica o movimento para o Rigidbody
        rb.velocity = new Vector3(moveDirectionX, rb.velocity.y, Mathf.Sign(targetZ - transform.position.z) * moveSpeed);
    }
}
