using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventorySlotView[] _slots;
    [SerializeField] private Text _textOwner;

    public string OwnerId
    {
        get => _textOwner.text;
        set => _textOwner.text = value;
    }

    public InventorySlotView GetInventorySlotView(int index)
    {
        return _slots[index];
    }
}
