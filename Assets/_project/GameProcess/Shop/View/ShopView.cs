using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopView : MonoBehaviour, IShopView
{
    [SerializeField] private Transform itemSlotsContainer;
    [SerializeField] private GameObject itemSlotPrefab;

    [SerializeField] private TMP_Text goldText;
    [SerializeField] private Button refreshButton;
    [SerializeField] private TMP_Text refreshCostText;
    [SerializeField] private TMP_Text refreshButtonText;
    [SerializeField] private Button closeButton;

    [SerializeField] StatsWindow statsWindow;

    [Inject] private ShopPresenter Presenter;
    [Inject] private PlayerModel playerModel;
    [Inject] private ShopConfiguration shopConfiguration;
    [Inject] private DiContainer container;

    private List<ShopItemSlotView> itemSlots = new();

    private void Start()
    {
        CreateItemSlots();

        Presenter.SetView(this);


        refreshButton.onClick.AddListener(() => Presenter.OnRefreshClicked());
        closeButton.onClick.AddListener(CloseShop);

        statsWindow.Subscribe(playerModel);


        CloseShop();
    }

    private void OnDestroy()
    {
        refreshButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();
    }

    private void CreateItemSlots()
    {
        foreach (Transform child in itemSlotsContainer)
        {
            Destroy(child.gameObject);
        }
        itemSlots.Clear();
        
        for (int i = 0; i < shopConfiguration.SlotCount; i++)
        {
            GameObject slotGO = Instantiate(itemSlotPrefab, itemSlotsContainer);
            RectTransform rt = slotGO.GetComponent<RectTransform>();
            rt.localScale = Vector3.one;
            
            container.InjectGameObject(slotGO);
            
            ShopItemSlotView slot = slotGO.GetComponent<ShopItemSlotView>();
            if (slot != null)
            {
                slot.SetPresenter(Presenter);
                slot.SetSlotIndex(i);
                itemSlots.Add(slot);
            }
        }
        
        LayoutRebuilder.ForceRebuildLayoutImmediate(itemSlotsContainer.GetComponent<RectTransform>());
    }

    public void DisplayItems(List<ItemConfiguration> items)
{
    itemSlots.RemoveAll(slot => slot == null);
    for (int i = 0; i < itemSlots.Count; i++)
    {
        if (i < items.Count)
        {
            itemSlots[i].SetItem(items[i]);
        }
        else
        {
            itemSlots[i].SetItem(null);
        }
    }
}

    public void UpdateGold(int gold)
    {
        goldText.text = $"Gold: {gold}";
    }

    public void UpdateRefreshButton(bool CanRefresh)
    {
        refreshButton.interactable = CanRefresh;
        refreshButtonText.color = CanRefresh ? Color.black : Color.red;
    }

    public void UpdateRefreshCost(int cost)
    {
        refreshCostText.text = cost.ToString();
    }

    public void UpdateAllSlots()
    {
        itemSlots.RemoveAll(slot => slot == null);
        foreach (var slot in itemSlots)
        {
            slot.UpdateUI();
        }
    }

    public void ShowRefreshError(string message)
    {
        Debug.Log(message);
    }

    public void ShowPurchaseError(string message)
    {
        Debug.Log(message);
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
        Presenter.OnOpenShop();
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    public void MarkAsPurchased(ItemConfiguration item)
    {
        foreach (var slot in itemSlots)
        {
            slot.MarkAsPurchasedIfMathces(item);
        }
    }

    public void MarkSlotAsPurchased(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < itemSlots.Count)
        {
            itemSlots[slotIndex].MarkAsPurchased();
        }
    }

}