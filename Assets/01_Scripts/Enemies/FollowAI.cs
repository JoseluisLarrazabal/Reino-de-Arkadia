using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;             // Velocidad del enemigo
    [SerializeField] private float minDistance;       // Distancia mínima para atacar
    [SerializeField] private float detectionRange;    // Rango de detección para comenzar a seguir al jugador
    [SerializeField] private Transform player;        // Referencia al jugador

    private Animator animator;
    private bool isFacingRight = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Calcula la distancia al jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Solo sigue al jugador si está dentro del rango de detección
        if (distanceToPlayer <= detectionRange)
        {
            animator.SetTrigger("NotIdle");
            Follow(distanceToPlayer);
        }
        else
        {
            animator.SetTrigger("Idle");
        }

        // Cambia la dirección en la que mira el enemigo si es necesario
        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);
    }

    private void Follow(float distanceToPlayer)
    {
        // Si la distancia al jugador es mayor que la distancia mínima, moverse hacia el jugador
        if (distanceToPlayer > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            // Si está dentro de la distancia mínima, atacar
            animator.SetTrigger("Attack");
        }
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
