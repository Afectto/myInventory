using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private ScreenView _screenView;

    private InventoryService _inventoryService;
    private ScreenController _screenController;

    private string _currentOwnerId;
    
    [NotNull] private const string OWNER_1 = "Afecto_1";
    [NotNull] private const string OWNER_2 = "Afecto_2";


    private readonly string[] _itemIds = {"Apple", "Armor", "Weapon", "Seed", "Potion"};
    
    void Start()
    {
        _inventoryService = new InventoryService();

        var inventoryData_1 = CreateTestInventory(OWNER_1, 3, 4);
        _inventoryService.RegisterInventory(inventoryData_1);

        var inventoryData_2 = CreateTestInventory(OWNER_2, 5, 5);
        _inventoryService.RegisterInventory(inventoryData_2);
        

        _screenController = new ScreenController(_inventoryService, _screenView);
        _screenController.OpenInventory(OWNER_1);
        _currentOwnerId = OWNER_1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _screenController.OpenInventory(OWNER_1);
            _currentOwnerId = OWNER_1;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _screenController.OpenInventory(OWNER_2);
            _currentOwnerId = OWNER_2;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(0, 100);
            _inventoryService.AddItemsToInventory(_currentOwnerId, rItemId, rAmount);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(0, 50);
            _inventoryService.RemoveItems(_currentOwnerId, rItemId, rAmount);
        }
    }

    private InventoryGridData CreateTestInventory(string ownerId, int sizeX, int sizeY)
    {
        var size = new Vector2Int(sizeX, sizeY);
        var createdInventorySlots = new List<InventorySlotData>();
        var length = sizeX + sizeY;

        for (int i = 0; i < length; i++)
        {
            createdInventorySlots.Add(new InventorySlotData());
        }
        var createInventoryData = new InventoryGridData
        {
            OwnerID = ownerId,
            Size = size,
            SlotsData = createdInventorySlots
        };
        return createInventoryData;
    }
}
