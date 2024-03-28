using System.Collections.Generic;
using UnityEngine;

public class GameStatePlayerPrefsProvider : IGameStateProvider, IGameStateSaver
{
    private const string KEY = "GAME STATE";
    
    public GameStateData GameState { get; private set; }
    
    public void SaveGameState()
    {
        var json = JsonUtility.ToJson(GameState);
        PlayerPrefs.SetString(KEY, json);
    }

    public void LoadGameState()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            var json = PlayerPrefs.GetString(KEY);
            GameState = JsonUtility.FromJson<GameStateData>(json);
        }
        else
        {
            GameState = InitFromSetting();
            SaveGameState();
        }
    }

    private GameStateData InitFromSetting()
    {
        var gameState = new GameStateData
        {
            Inventories = new List<InventoryGridData>
            {
                CreateInventory("Afecto", 2 , 3)
            }
        };
        return gameState;
    }
    
    
    private InventoryGridData CreateInventory(string ownerId, int sizeX, int sizeY)
    {
        var size = new Vector2Int(sizeX, sizeY);
        var createdInventorySlots = new List<InventorySlotData>();
        var length = sizeX + sizeY + 1;

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