using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    private int totalCoins;
    private int totalItems;
    private int itemPrice;


    [SerializeField] private TMP_Text coinText;
    [SerializeField] private List<GameObject> heartList;
    [SerializeField] private Sprite disabledHeart;
    [SerializeField] private Sprite enabledHeart;
    [SerializeField] private GameObject textBox;
    [SerializeField] private TMP_Text textDialog;

    [SerializeField] private GameObject panelEquipment;



    private void Start()
    {
        Coins.addCoin += AddCoins;
    }

    private void AddCoins(int coin)
    {
        totalCoins += coin;
        coinText.text = totalCoins.ToString();
    }
    public void AddHearths(int index)
    {
        Image heartImage = heartList[index].GetComponent<Image>();
        heartImage.sprite = enabledHeart;
    }
    public void SubstractHearts(int index)
    {
        Image heartImage = heartList[index].GetComponent<Image>();
        heartImage.sprite = disabledHeart;
    }

    public void EnableDisableText(bool enabled)
    {
        textBox.SetActive(enabled);
    }

    public void ShowText (string text)
    {
        textDialog.text = text = text.ToString();
    }

    #region STORE

    public void ItemPrice(string item)
    {
        switch (item)
        {
            case "SmallPotion":
                itemPrice = 1;
                break;
            case "MediumPotion":
                itemPrice = 3;
                break;
            case "LargePotion":
                itemPrice = 5;
                break;
            case "SpeedPotion":
                itemPrice = 8;
                break;
        }
    }

    public void GetItem (string item)
    {
        ItemPrice(item);

        if (totalCoins >= itemPrice && totalItems < 3)
        {
            totalItems++;
            totalCoins -= itemPrice;
            coinText.text = totalCoins.ToString();
            
            GameObject equipment = (GameObject)Resources.Load(item);
            Instantiate(equipment, Vector3.zero, Quaternion.identity, panelEquipment.transform);
        }
    }


    #endregion
}
