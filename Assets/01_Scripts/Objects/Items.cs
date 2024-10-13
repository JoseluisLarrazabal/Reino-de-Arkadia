using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public enum TypeOfItems
    {
        SmallPotion,
        MediumPotion,
        LargePotion,
        Speed
    };

    [SerializeField] TypeOfItems typeOfItems;

    public void UseItem()
    {
        Player player = GameObject.FindObjectOfType<Player>();

        switch (typeOfItems)
        {
            case TypeOfItems.SmallPotion:
                player.AddHealth();
                Debug.Log("Heals for 1 point health.");
                break;
            case TypeOfItems.MediumPotion:
                player.AddHealth();
                Debug.Log("Heals for 2 points health.");
                break;
            case TypeOfItems.LargePotion:
                Debug.Log("Heals for 3 points health.");
                break;
            case TypeOfItems.Speed:
                Debug.Log("Enhances overall speed.");
                break;
        }

        Destroy(gameObject);
    }
}
