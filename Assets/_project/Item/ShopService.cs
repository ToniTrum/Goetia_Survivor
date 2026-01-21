using System;
using Zenject;

public class ShopService
{
    [Inject] private readonly PlayerModel Model;

    public bool CanBuyItem(ItemConfiguration itemConfiguration)
    {
        return Model.TrySpendGold(itemConfiguration.Cost);
    }

    public bool TryBuyItem(ItemConfiguration itemConfiguration)
    {
        if(!CanBuyItem(itemConfiguration))
            return false;
        
        Model.SpendGold(itemConfiguration.Cost);

        Item item = new Item(itemConfiguration);
        Model.Inventory.AddItem(item);
        item.Apply(Model);

        return true;
    }
}