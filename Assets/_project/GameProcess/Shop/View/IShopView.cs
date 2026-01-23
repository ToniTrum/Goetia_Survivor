using System.Collections.Generic;

public interface IShopView
{
    void DisplayItems(List<ItemConfiguration> items);
    void UpdateGold(int gold);
    void UpdateRefreshButton(bool CanRefresh);
    void UpdateRefreshCost(int cost);
    void UpdateAllSlots();
    void ShowPurchaseError(string message);
    void ShowRefreshError(string message);
    void MarkSlotAsPurchased(int slotIndex);
}