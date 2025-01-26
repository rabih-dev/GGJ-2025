using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 5f;  // Velocidade de movimento do kamikaze
    private Rigidbody rb;  // Referência ao Rigidbody
    private Vector3 moveDirection;  // Direção fixa de movimento

    void Start()
    {
        transform.parent = null;
        // Obtém a referência do Rigidbody do objeto
        rb = GetComponent<Rigidbody>();

        // Procura o objeto com a tag "Player" e pega sua referência
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Calcula a direção do movimento em relação ao Player e normaliza para manter a velocidade constante
            moveDirection = (player.transform.position - transform.position).normalized;
        }
        else
        {
            Debug.LogWarning("Nenhum objeto com a tag 'Player' encontrado.");
            // Caso não haja um player, a bala se move para frente
            moveDirection = transform.forward;  // Movimento em linha reta
        }

        // Destrói a bala após 4 segundos, para evitar objetos persistentes
        Destroy(this.gameObject, 4f);
    }

    void FixedUpdate()
    {
        // Move a bala em direção à direção fixa
        rb.velocity = moveDirection * moveSpeed;  // Aplicando velocidade no Rigidbody
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verifica se o objeto colidido é o Player
        if (other.gameObject.CompareTag("Player"))
        {
            // Causa dano
            Destroy(this.gameObject);
        }
    }
}
