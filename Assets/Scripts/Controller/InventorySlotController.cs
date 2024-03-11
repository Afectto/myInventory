using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotController
{
    private readonly InventorySlotView _view;

    public InventorySlotController(IReadOnlyInventorySlot slot, InventorySlotView view)
    {
        _view = view;

        slot.ItemIdChange += onSlotItemIdChanged;
        slot.ItemAmountChange += onSlotItemAmountChange;

        view.Title = slot.ItemId;
        view.Amount = slot.Amount;
    }

    private void onSlotItemAmountChange(int newAmount)
    {
        _view.Amount = newAmount;
    }

    private void onSlotItemIdChanged(string newItemId)
    {
        _view.Title = newItemId;
    }
}
