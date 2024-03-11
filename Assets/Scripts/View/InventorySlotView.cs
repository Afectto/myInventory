using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Text _textTitle;
    [SerializeField] private Text _textAmount;
    
    public string Title
    {
        get => _textTitle.text;
        set => _textTitle.text = value;
    }
    
    public int Amount
    {
        get => Convert.ToInt32(_textAmount.text);
        set => _textAmount.text = value == 0 ? "" : value.ToString();
    }
}
