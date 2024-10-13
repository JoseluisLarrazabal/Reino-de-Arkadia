using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieWeapon : MonoBehaviour
{
    private BoxCollider2D WeaponCollider;
    void Start()
    {
        WeaponCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player p = collision.gameObject.GetComponent<Player>();
            p.TakeDamage();
        }
    }
}
