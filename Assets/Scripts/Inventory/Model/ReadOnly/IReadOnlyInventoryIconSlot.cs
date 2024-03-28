using System;

// public interface IReadOnlyInventoryIconSlot : IReadOnlyInventorySlot
// {
//         
//     event Action<Sprite> ItemIconChange;
//     event Action<int> ItemPriceChange;
//
//     Sprite Icon { get; }
//     int Price { get; }
// }
public interface IReadOnlyInventorySlot<TItem, TNumber>
{
    event Action<TItem> ItemChange;
    event Action<TNumber> ItemNumberChange;
    
    TItem Item { get; }
    TNumber Amount { get; }
    bool IsEmpty { get; }
}