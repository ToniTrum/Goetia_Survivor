using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Transform itemSlotsContainer;
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Button refreshButton;
    [SerializeField] private TMP_Text refreshCostText;
    [SerializeField] private TMP_Text GoldText;
    [SerializeField] private TMP_Text refreshButtonText;
    [SerializeField] private Button closeButton;

    [SerializeField] private StatsWindow statsWindow;

    [Inject] private readonly ShopService ShopService;
    [Inject] private readonly PlayerModel PlayerModel;

    [Inject] private readonly ShopConfiguration shopConfiguration;
    [Inject] private readonly DiContainer container;

    private List<ItemShopSlot> itemSlots = new List<ItemShopSlot>();

    private void Start()
    {
        CreateItemSlots();

        refreshCostText.text = shopConfiguration.RefreshCost.ToString();

        refreshButton.onClick.AddListener(OnRefreshClicked);
        closeButton.onClick.AddListener(CloseShop);

        PlayerModel.OnGoldChanged += OnGoldChanged;

        ShopService.OnShopRefreshed += OnShopRefreshed;
        ShopService.OnItemPurchased += OnItemPurchased;

        statsWindow.Subscribe(PlayerModel);
        GoldText.text = $"Gold: {PlayerModel.Gold}";

        UpdateItemSlots();
        UpdateRefreshButton();

        CloseShop();

    }

    private void OnDestroy()
    {
        if(PlayerModel != null)
            PlayerModel.OnGoldChanged -= OnGoldChanged;

        if(ShopService != null)
        {
            ShopService.OnShopRefreshed -= OnShopRefreshed;
            ShopService.OnItemPurchased -= OnItemPurchased;
        }        
    }

    private void CreateItemSlots()
    {
        foreach(Transform child in itemSlotsContainer)
        {
            Destroy(child.gameObject);
        }
        itemSlots.Clear();
        Debug.Log(shopConfiguration.SlotCount);
        for(int i = 0; i < shopConfiguration.SlotCount; i++)
        {
            GameObject slotGO = Instantiate(itemSlotPrefab, itemSlotsContainer);
            RectTransform rectTransform = slotGO.GetComponent<RectTransform>();
            rectTransform.localScale = Vector3.one;
            container.InjectGameObject(slotGO);

            ItemShopSlot slot = slotGO.GetComponent<ItemShopSlot>();
            itemSlots.Add(slot);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(itemSlotsContainer.GetComponent<RectTransform>());
    }

    private void UpdateItemSlots()
    {

        itemSlots.RemoveAll(slot => slot == null);
        for(int i = 0; i < itemSlots.Count; i++)
        {
            if(i < ShopService.CurrentShopItems.Count)
            {
                itemSlots[i].SetItem(ShopService.CurrentShopItems[i]);
            }
            else
            {
                itemSlots[i].SetItem(null);
            }
        }
    }

    private void UpdateRefreshButton()
    {
        bool CanRefreshShop = ShopService.CanRefreshShop();
        refreshButton.interactable = CanRefreshShop;
        refreshButtonText.color = CanRefreshShop ? Color.black : Color.red;
    }

    private void OnRefreshClicked()
    {
        if(ShopService.TryRefreshShop())
        {
            Debug.Log("Магазин Обновлён");
        }
        else
        {
            Debug.Log("Недостаточно золота для обновления!");
        }
    }

    private void OnGoldChanged(int value)
    {
        UpdateGoldText(value);
        UpdateRefreshButton();
    }

    private void OnItemPurchased(ItemConfiguration item)
    {
        UpdateRefreshButton();
    }

    private void OnShopRefreshed()
    {
        CreateItemSlots();
        UpdateItemSlots();
        UpdateRefreshButton();
    }

    private void UpdateGoldText(int value)
    {
        GoldText.text = $"Gold: {value}";
    }

    public void OpenShop()
    {
        gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

}