using System;
using UnityEngine;


public interface IReadOnlyInventoryList: IReadOnlyInventory
{
    event Action<int> SizeChange;
    
    int Size { get; }

    IReadOnlyInventorySlot[,] GetSlots(); 
}
