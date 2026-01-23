using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel
{
    private readonly ShopConfiguration shopConfiguration;
    private readonly PlayerModel playerModel;
    public List<ItemConfiguration> CurrentItems { get; private set; }
    public int RefreshCost => shopConfiguration.RefreshCost;
    public int SlotCount => shopConfiguration.SlotCount;

    public event Action OnItemsChanged;
    public event Action<ItemConfiguration> OnItemPurchased;

    public ShopModel(ShopConfiguration shopConfiguration, PlayerModel playerModel)
    {
        this.shopConfiguration = shopConfiguration;
        this.playerModel = playerModel;
        CurrentItems = new();
    }

    public bool CanBuyItem(ItemConfiguration itemConfiguration)
    {
        if(itemConfiguration == null) return false;
        return playerModel.Gold >= itemConfiguration.Cost;
    }

    public bool CanRefresh()
    {
        return playerModel.Gold >= RefreshCost;
    }

    public bool TryBuyItem(ItemConfiguration item)
    {
        if(!CanBuyItem(item))
            return false;

        playerModel.SpendGold(item.Cost);

        Item purchasedItem = new(item);
        playerModel.Inventory.AddItem(purchasedItem);
        purchasedItem.Apply(playerModel);

        OnItemPurchased?.Invoke(item);
        return true;
    }

    public bool TryRefreshShop()
    {
        if(!CanRefresh())
            return false;
        
        playerModel.SpendGold(RefreshCost);
        GenerateRandomItems();
        return true;
    }

    public void GenerateRandomItems()
    {
        CurrentItems.Clear();
        
        if (shopConfiguration.AvaliableItems == null || shopConfiguration.AvaliableItems.Count == 0)
        {
            Debug.LogWarning("No items available in shop config!");
            return;
        }
        
        for (int i = 0; i < SlotCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, shopConfiguration.AvaliableItems.Count);
            CurrentItems.Add(shopConfiguration.AvaliableItems[randomIndex]);
        }
        
        OnItemsChanged?.Invoke();
        Debug.Log($"Shop items generated: {CurrentItems.Count}");
    }
}