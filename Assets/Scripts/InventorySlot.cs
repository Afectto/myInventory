using System;

public class InventorySlot : IReadOnlyInventorySlot
{
    public event Action<string> ItemIdChange;
    public event Action<int> ItemAmountChange;

    public string ItemId
    {
        get => _data.itemID;
        set
        {
            if (_data.itemID != value)
            {
                _data.itemID = value;
                ItemIdChange?.Invoke(value);
            }
        }

    }
    public int Amount {        
        get => _data.amount;
        set
        {
            if (_data.amount != value)
            {
                _data.amount = value;
                ItemAmountChange?.Invoke(value);
            }
        }}

    public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemId);

    private readonly InventorySlotData _data;

    public InventorySlot(InventorySlotData data)
    {
        _data = data;
    }

}