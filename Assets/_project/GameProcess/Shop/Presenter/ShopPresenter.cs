using UnityEngine;
using Zenject;

public class ShopPresenter
{
    private readonly ShopModel model;
    private readonly PlayerModel playerModel;
    private IShopView shopView;

    public ShopModel Model => model;

    [Inject]
    public ShopPresenter(ShopModel model, PlayerModel playerModel)
    {
        this.model = model;
        this.playerModel = playerModel;

        model.OnItemsChanged += OnItemsChanged;
        model.OnItemPurchased += OnItemPurchased;

        playerModel.OnGoldChanged += OnGoldChanged;
    

        model.GenerateRandomItems();
    }

    public void SetView(IShopView shopView)
    {
        this.shopView = shopView;
        
        if(shopView != null)
        {
            UpdateView();
        }
    }

    public void OnBuyItemClicked(ItemConfiguration item, int slotIndex)
{
    if (model.TryBuyItem(item))
    {
        Debug.Log($"Item purchased: {item.Name} from slot {slotIndex}");
        shopView?.MarkSlotAsPurchased(slotIndex);
    }
    else
    {
        Debug.Log("Not enough gold!");
        shopView?.ShowPurchaseError("Недостаточно золота!");
    }
}

    public void OnRefreshClicked()
    {
        if(model.TryRefreshShop())
        {
            Debug.Log("Shop refreshed");
        }
        else
        {
            Debug.Log("Cannot refresh shop - not enough gold!");
        }
    }

    public void OnOpenShop()
    {
        UpdateView();
    }

    private void OnItemsChanged()
    {
        UpdateView();
    }

    private void OnItemPurchased(ItemConfiguration item)
    {
        shopView?.UpdateAllSlots();
        shopView?.UpdateRefreshButton(model.CanRefresh());
    }

    private void OnGoldChanged(int newGoldValue)
    {
        shopView?.UpdateGold(newGoldValue);
        shopView?.UpdateAllSlots();
        shopView?.UpdateRefreshButton(model.CanRefresh());
    }

    private void UpdateView()
    {
        if(shopView == null)
            return;

        shopView?.DisplayItems(model.CurrentItems);
        shopView?.UpdateGold(playerModel.Gold);
        shopView?.UpdateRefreshButton(model.CanRefresh());
        shopView?.UpdateRefreshCost(model.RefreshCost);
    }
}