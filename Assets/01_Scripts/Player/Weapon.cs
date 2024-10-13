using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private BoxCollider2D WeaponCollider;
    public GameObject[] coins;
    void Start()
    {
        WeaponCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Orc"))
        {
            Destroy(collision.gameObject);
            int i = Random.Range(0, 2);
            Instantiate(coins[i], transform.position, transform.rotation);
        }
    }
}
