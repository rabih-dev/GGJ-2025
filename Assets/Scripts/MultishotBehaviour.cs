using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultishotBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 5f;  // Velocidade do movimento
    [SerializeField] private float targetDistance = 3f;  // Distância alvo ao redor do player (raio da órbita)
    private Rigidbody rb;  // Referência ao Rigidbody
    private Transform targetPlayer;  // Referência ao Player
    private float angle = 0f;  // Ângulo de rotação ao redor do player

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
            // Move e faz a bala girar ao redor do jogador
            RotateAroundPlayer();
        }
    }

    private void RotateAroundPlayer()
    {
        // A bala gira em torno do jogador no plano XZ mantendo a distância constante
        angle += moveSpeed * Time.fixedDeltaTime;  // Incrementa o ângulo (giro) a cada frame

        // Converte o ângulo para posições em X e Z
        float targetX = targetPlayer.position.x + Mathf.Cos(angle) * targetDistance;
        float targetZ = targetPlayer.position.z + Mathf.Sin(angle) * targetDistance;

        // Atualiza a posição da bala
        rb.velocity = new Vector3(Mathf.Sign(targetX - transform.position.x) * moveSpeed, rb.velocity.y, Mathf.Sign(targetZ - transform.position.z) * moveSpeed);

        // Faz a bala olhar para o centro do movimento (o jogador)
        Vector3 direction = targetPlayer.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direction);  // Faz a rotação da bala apontando para o jogador
    }
}
