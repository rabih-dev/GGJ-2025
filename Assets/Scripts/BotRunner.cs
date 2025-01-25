using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRunner : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] float moveSpeed;
    private Vector2 moveInput;
    private Vector2 moveForce;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    // A direção fixa inicial do bot
    private Vector2 botDirection = Vector2.right;

    // Tempo mínimo e máximo para o cooldown de direção
    [SerializeField] private float minCooldown = 1f;
    [SerializeField] private float maxCooldown = 3f;

    void Start()
    {
        // Inicia a coroutine para mudar a direção após um tempo aleatório
        StartCoroutine(ChangeDirectionRandomly());
    }

    void Update()
    {
        // Você pode adicionar mais lógicas aqui se precisar
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        // Usa a direção atual do bot
        moveInput = botDirection.normalized;

        // Multiplicando por 100 para não ter números grandes no Inspector
        moveForce = moveInput * moveSpeed * 100 * Time.fixedDeltaTime;

        // Movendo o bot para a direção escolhida
        rb.velocity = new Vector3(moveForce.x, rb.velocity.y, moveForce.y);

        // Opcional: para debugar e ver a direção
        print("input direção: " + moveInput);
        print("force aplicada: " + moveForce);
    }

    private IEnumerator ChangeDirectionRandomly()
    {
        // Fica em um loop contínuo, mudando a direção após um tempo aleatório
        while (true)
        {
            // Atraso aleatório entre o mínimo e o máximo
            float cooldownTime = Random.Range(minCooldown, maxCooldown);
            yield return new WaitForSeconds(cooldownTime);

            // Muda a direção aleatoriamente
            ChangeRandomDirection();
        }
    }

    private void ChangeRandomDirection()
    {
        // Cria um vetor de direção aleatória
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        // Normaliza para garantir que o vetor tenha magnitude 1 (não se mova mais rápido)
        botDirection = new Vector2(randomX, randomY).normalized;
    }

    private void OnCollisionEnter(Collision other) 
    {
        // Chama o método de mudança de direção quando o bot colide com algo
        ChangeRandomDirection();
    }
}
