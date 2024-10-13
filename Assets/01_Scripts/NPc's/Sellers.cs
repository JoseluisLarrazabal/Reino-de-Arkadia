using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sellers : MonoBehaviour
{
    [SerializeField] private GameObject store;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        store.SetActive(true);
    }
}
