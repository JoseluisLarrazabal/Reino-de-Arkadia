using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string [] textArray;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Player player;

    private int index;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnMouseDown()
    {
        float distance = Vector2.Distance(gameObject.transform.position, player.transform.position);

        if (distance <= 2)
        {
            uiManager.EnableDisableText(true);
            player.CheckIfImTalking(true);
            ActivateDialog();
        }
    }

     void ActivateDialog()
    {
        if (index < textArray.Length)
        {
            uiManager.ShowText(textArray[index]);
            index++;
        }
        else
        {
            uiManager.EnableDisableText(false);
            player.CheckIfImTalking(false);
            index = 0;

        }
    }
}
