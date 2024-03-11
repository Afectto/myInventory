using System.Collections.Generic;

public class InventoryGridController
{
    private readonly List<InventorySlotController> _slotControllers = new List<InventorySlotController>();
    
    public InventoryGridController(IReadOnlyInventoryGrid inventoryGrid, InventoryView view)
    {
        var size = inventoryGrid.Size;
        var slots = inventoryGrid.GetSlots();
        var lineLenght = size.y;

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                var index = i * lineLenght + j;
                var slotView = view.GetInventorySlotView(index);
                var slot = slots[i, j];
                
                _slotControllers.Add(new InventorySlotController(slot, slotView));
            }
        }

        view.OwnerId = inventoryGrid.OwnerId;
    }
}