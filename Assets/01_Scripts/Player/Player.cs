using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D Weapon;
    [SerializeField] UIManager uiManager;

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spritePlayer;
    private float posColliderX = 1;
    private float posColliderY = 0;
    private int playerLife = 3;
    private bool talkToNpcs;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spritePlayer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        // Obtener el punto de spawn guardado
        string spawnPointName = PlayerPrefs.GetString("SpawnPoint", "");

        // Si hay un punto de spawn guardado, mover al jugador allí
        if (!string.IsNullOrEmpty(spawnPointName))
        {
            GameObject spawnPoint = GameObject.Find(spawnPointName);
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Update()
    {
        Attack();
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage();
        }
    }

    public void CheckIfImTalking(bool talking)
    {
        talkToNpcs = talking;
    }

    public void TakeDamage()
    {
        if (playerLife > 0)
        {
            playerLife--;
            uiManager.SubstractHearts(playerLife);

            if (playerLife <= 0)
            {
                animator.SetTrigger("Die");
                Invoke(nameof(Die), 1f);
            }
        }
    }
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (talkToNpcs == false)
        {
            rb.velocity = new Vector2(horizontal, vertical) * speed;
            animator.SetFloat("Walk", Mathf.Abs(rb.velocity.magnitude));

        }

        if (horizontal > 0)
        {
            Weapon.offset = new Vector2(posColliderX, posColliderY);
            spritePlayer.flipX = false;
        } 
        else if (horizontal < 0)
        {
            Weapon.offset = new Vector2(-posColliderX, posColliderY);
            spritePlayer.flipX = true;
        }

    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && talkToNpcs == false)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void AddHealth()
    {
        if (playerLife < 3)
        {
            uiManager.AddHearths(playerLife);
            playerLife++;
        }
    }
    
}
