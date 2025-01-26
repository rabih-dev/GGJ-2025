using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator playerVisual;
    [SerializeField] AnimationClip[] idleRex;
    [SerializeField] AnimationClip[] walkRex;

    private bool isFacingRight = true;
    private bool wasMovingUp = false;  // Variável para armazenar a última direção
    private bool wasMovingLeft = false;  // Variável para armazenar a última direção
    private bool wasMovingRight = false;  // Variável para armazenar a última direção
    private bool wasMovingBack = false;  // Variável para armazenar a última direção

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Verifica se a tecla W, A, S ou D está pressionada
        bool isMovingUp = Input.GetKey(KeyCode.W);
        bool isMovingDown = Input.GetKey(KeyCode.S);
        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);

        // Se o jogador estiver se movendo
        if (isMovingUp || isMovingDown || isMovingLeft || isMovingRight)
        {
            // Inicializa todas as direções como false
            wasMovingUp = false;
            wasMovingLeft = false;
            wasMovingRight = false;
            wasMovingBack = false;

            // Determina a animação de movimento com base na direção
            if (isMovingUp && isMovingLeft)
            {
                playerVisual.Play(walkRex[3].name); // Caminhando para cima e para a esquerda
                FlipSprite(false);  // Espelhar
                wasMovingUp = true;
                wasMovingLeft = true;
                wasMovingRight = false;
                wasMovingBack = false;
            }
            else if (isMovingUp && isMovingRight)
            {
                playerVisual.Play(walkRex[3].name); // Caminhando para cima e para a direita
                FlipSprite(true);  // Não espelhar
                wasMovingUp = true;
                wasMovingLeft = false;
                wasMovingRight = true;
                wasMovingBack = false;
            }
            else if (isMovingDown && isMovingLeft)
            {
                playerVisual.Play(walkRex[1].name); // Caminhando para baixo e para a esquerda
                FlipSprite(false);  // Espelhar
                wasMovingUp = false;
                wasMovingLeft = true;
                wasMovingRight = false;
                wasMovingBack = true;
            }
            else if (isMovingDown && isMovingRight)
            {
                playerVisual.Play(walkRex[1].name); // Caminhando para baixo e para a direita
                FlipSprite(true);  // Não espelhar
                wasMovingUp = false;
                wasMovingLeft = false;
                wasMovingRight = true;
                wasMovingBack = true;
            }
            else if (isMovingLeft)
            {
                playerVisual.Play(walkRex[2].name); // Caminhando para a esquerda
                FlipSprite(false);  // Espelhar
                wasMovingUp = false;
                wasMovingLeft = true;
                wasMovingRight = false;
                wasMovingBack = false;
            }
            else if (isMovingRight)
            {
                playerVisual.Play(walkRex[2].name); // Caminhando para a direita
                FlipSprite(true);  // Não espelhar
                wasMovingUp = false;
                wasMovingLeft = false;
                wasMovingRight = true;
                wasMovingBack = false;
            }
            else if (isMovingDown)
            {
                playerVisual.Play(walkRex[0].name); // Caminhando para baixo
                wasMovingUp = false;
                wasMovingLeft = false;
                wasMovingRight = false;
                wasMovingBack = true;
            }
            else if (isMovingUp)
            {
                playerVisual.Play(walkRex[4].name); // Caminhando para cima
                wasMovingUp = true;
                wasMovingLeft = false;
                wasMovingRight = false;
                wasMovingBack = false;
            }
        }
        else
        {
            // Quando o jogador não está se movendo, fica na animação idle
            if (wasMovingLeft && wasMovingBack)
            {
                playerVisual.Play(idleRex[1].name);  // Idle olhando para a esquerda
            }
            else if (wasMovingRight && wasMovingBack)
            {
                playerVisual.Play(idleRex[1].name);  // Idle olhando para a direita
            }
            else if (wasMovingLeft && wasMovingUp)
            {
                playerVisual.Play(idleRex[3].name);  // Idle olhando para a esquerda
            }
            else if (wasMovingRight && wasMovingUp)
            {
                playerVisual.Play(idleRex[3].name);  // Idle olhando para a direita
            }
            else if (wasMovingRight)
            {
                playerVisual.Play(idleRex[2].name);  // Idle olhando para a direita
            }
            else if (wasMovingUp)
            {
                playerVisual.Play(idleRex[4].name);  // Idle olhando para cima
            }
            else if (wasMovingLeft)
            {
                playerVisual.Play(idleRex[2].name);  // Idle olhando para a esquerda
            }
            else if (wasMovingBack)
            {
                playerVisual.Play(idleRex[0].name);  // Idle olhando para a esquerda
            }
        }
    }

    private void FlipSprite(bool flip)
    {
        if (isFacingRight && flip)
        {
            // Inverte o sprite para a esquerda
            playerVisual.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            isFacingRight = false;
        }
        else if (!isFacingRight && !flip)
        {
            // Inverte o sprite de volta para a direita
            playerVisual.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            isFacingRight = true;
        }
    }
}
