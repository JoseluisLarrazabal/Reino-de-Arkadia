using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public delegate void AddCoin(int coin);
    public static event AddCoin addCoin;

    [SerializeField] private int coinQuantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (addCoin != null)
            {
                AddCoins();
                Destroy(this.gameObject);
            }
        }
    }

    private void AddCoins()
    {
        addCoin(coinQuantity);
    }
}
