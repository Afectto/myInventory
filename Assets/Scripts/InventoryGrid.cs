using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : IReadOnlyInventoryGrid
{
    public event Action<string, int> ItemAdded;
    public event Action<string, int> ItemRemoved;
    public event Action<Vector2Int> SizeChange;

    public string OwnerId => _data.OwnerID;
    
    public Vector2Int Size {        
        get => _data.Size;
        set
        {
            if (_data.Size != value)
            {
                _data.Size = value;
                SizeChange?.Invoke(value);
            }
        }}

    private readonly InventoryGridData _data;
    private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new Dictionary<Vector2Int, InventorySlot>();
    
    public InventoryGrid(InventoryGridData data)
    {
        _data = data;

        var size = _data.Size;
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var index = i * size.y + j;
                var slotData = data.SlotsData[index];
                var slot = new InventorySlot(slotData);
                var position = new Vector2Int(i,j);
                
                _slotsMap[position] = slot;
            }
        }
    }
    
    public IReadOnlyInventorySlot[,] GetSlots()
    {
        var array = new IReadOnlyInventorySlot[Size.x, Size.y];

        for (int i = 0; i < Size.x; i++)
        {
            for (int j = 0; j < Size.y; j++)
            {
                var position = new Vector2Int(i, j);
                array[i, j] = _slotsMap[position];
            }
        }

        return array;
    }
    
    public int GetAmount(string itemId)
    {
        throw new NotImplementedException();
    }

    public bool Has(string itemId, int amount)
    {
        throw new NotImplementedException();
    }
}