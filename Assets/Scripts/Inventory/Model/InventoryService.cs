using System.Collections.Generic;
using UnityEngine;

public class InventoryService
{
    private readonly Dictionary<string, InventoryGrid> _inventoriesMap = new Dictionary<string, InventoryGrid>();
    private readonly IGameStateSaver _saver;

    public InventoryService(IGameStateSaver saver)
    {
        _saver = saver;
    }

    public InventoryGrid RegisterInventory(InventoryGridData inventoryGridData)
    {
        var inventory = new InventoryGrid(inventoryGridData);
        _inventoriesMap[inventory.OwnerId] = inventory;
        return inventory;
    }

    public AddItemsToInventoryGridResult AddItemsToInventory(string ownerId, string itemsId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];
        var result = inventory.AddItem(itemsId, amount);
        
        _saver.SaveGameState();
        
        return result;
    }
    public AddItemsToInventoryGridResult AddItemsToInventory(string ownerId, Vector2Int slotCoords, string itemsId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];
        var result =  inventory.AddItem(slotCoords, itemsId, amount);
              
        _saver.SaveGameState();
        
        return result;
    }

    public RemoveItemsFromInventoryGridResult RemoveItems(string ownerId, string itemsId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];
        var result = inventory.RemoveItems(itemsId, amount);
        
        _saver.SaveGameState();
        
        return result;
    }

    public RemoveItemsFromInventoryGridResult RemoveItems(string ownerId, Vector2Int slotCoords, string itemsId,
        int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];
        var result =  inventory.RemoveItems(slotCoords, itemsId, amount);
              
        _saver.SaveGameState();
        
        return result;
    }

    public void CleanInventory(string ownerId)
    {
        var inventory = _inventoriesMap[ownerId];
        inventory.CleanInventory();
    }

    public bool Has(string ownerId, string itemId, int amount)
    {
        var inventory = _inventoriesMap[ownerId];
        return inventory.Has(itemId, amount);
    }

    public IReadOnlyInventoryGrid GetInventory(string ownerId)
    {
        return _inventoriesMap[ownerId];
    }

}
