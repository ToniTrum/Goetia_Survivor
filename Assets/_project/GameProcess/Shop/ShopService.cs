using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class ShopService
{
    private readonly PlayerModel Model;
    private readonly ShopConfiguration shopConfig;

    public List<ItemConfiguration> CurrentShopItems { get; private set; }

    public event Action<ItemConfiguration> OnItemPurchased;
    public event Action OnShopRefreshed;

    [Inject]
    public ShopService(PlayerModel playerModel, ShopConfiguration shopConfiguration)
    {
        Model = playerModel;
        shopConfig = shopConfiguration;

        CurrentShopItems = new();

        RefreshShop(true);
    }

    public bool CanBuyItem(ItemConfiguration itemConfiguration)
    {
        return Model.TrySpendGold(itemConfiguration.Cost);
    }

    public bool CanRefreshShop()
    {
        return shopConfig.RefreshCost <= Model.Gold;
    }

    public bool TryBuyItem(ItemConfiguration itemConfiguration)
    {
        if(!CanBuyItem(itemConfiguration))
            return false;
        
        Model.SpendGold(itemConfiguration.Cost);

        Item item = new(itemConfiguration);
        Model.Inventory.AddItem(item);
        item.Apply(Model);

        OnItemPurchased?.Invoke(itemConfiguration);
        return true;
    }

    public bool TryRefreshShop()
    {
        if(!CanRefreshShop())
            return false;

        Model.SpendGold(shopConfig.RefreshCost);
        RefreshShop(free: false);
        return true;
    }


    public void RefreshShop(bool free)
    {

        CurrentShopItems.Clear();
        if(shopConfig.AvaliableItems == null || shopConfig.AvaliableItems.Count == 0)
        {
            Debug.LogWarning("Empty Item Pool!");
            return;
        }

        List<ItemConfiguration> randomItems = GetRandomItems(shopConfig.SlotCount);

        foreach(var item in randomItems)
        {
            CurrentShopItems.Add(item);
        }

        OnShopRefreshed?.Invoke();
    }

    private List<ItemConfiguration> GetRandomItems(int count)
    {
        List<ItemConfiguration> res = new();
        for(int i = 0; i < count; i++)
        {
            int indx = UnityEngine.Random.Range(0, shopConfig.AvaliableItems.Count);
            res.Add(shopConfig.AvaliableItems[indx]);
        }
        return res;
    }
}