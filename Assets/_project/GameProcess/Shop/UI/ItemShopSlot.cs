using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ItemShopSlot : MonoBehaviour
{
    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private Image ItemImage;
    [SerializeField] private TMP_Text ItemDescription;
    [SerializeField] private TMP_Text Cost;
    [SerializeField] private Button BuyButton;
    
    private ItemConfiguration currentItem;
    
    [Inject] private ShopService shopService;
    [Inject] private PlayerModel playerModel;
    
    private bool isInitialized = false;
    
    private void Start()
    {
        if (shopService == null)
        {
            return;
        }
        
        if (playerModel == null)
        {
            return;
        }

        BuyButton.onClick.AddListener(OnBuyButtonClicked);

        playerModel.OnGoldChanged += OnGoldChanged;
        shopService.OnItemPurchased += OnItemPurchased;
        
        isInitialized = true;
        
        if (currentItem != null)
        {
            UpdateUI();
        }
    }
    
    private void OnDestroy()
    {
        if (BuyButton != null)
        {
            BuyButton.onClick.RemoveListener(OnBuyButtonClicked);
        }
        
        if (playerModel != null)
        {
            playerModel.OnGoldChanged -= OnGoldChanged;
        }
        
        if (shopService != null)
        {
            shopService.OnItemPurchased -= OnItemPurchased;
        }
    }
    
    public void SetItem(ItemConfiguration itemConfiguration)
    {
        currentItem = itemConfiguration;
        
        if (currentItem == null)
        {
            HideSlot();
            return;
        }
        
        ShowSlot();
    }
    
    private void ShowSlot()
    {
        gameObject.SetActive(true);
        
        if (currentItem == null) return;
        
        ItemName.text = currentItem.Name;
        ItemImage.sprite = currentItem.ItemImage;
        Cost.text = currentItem.Cost.ToString();
        ItemDescription.text = currentItem.Effect?.GetDescription() ?? "no description";
        
        if (isInitialized)
        {
            UpdateUI();
        }
    }
    
    private void HideSlot()
    {
        gameObject.SetActive(false);
    }
    
    private void UpdateUI()
    {
        if (!isInitialized || currentItem == null || shopService == null || playerModel == null)
            return;
        
        bool canBuy = shopService.CanBuyItem(currentItem);
        
        BuyButton.interactable = canBuy;
        Cost.color = canBuy ? Color.white : Color.gray;
        
        var buttonText = BuyButton.GetComponentInChildren<TMP_Text>();
        if (buttonText != null)
        {
            buttonText.text = "Buy!";
        }
    
    }
    
    public void OnBuyButtonClicked()
    {
        if (currentItem == null)
        {
            Debug.LogWarning("Trying to buy null item!");
            return;
        }
        
        if (shopService.TryBuyItem(currentItem))
        {
            Debug.Log($"Куплен предмет: {currentItem.Name}");
            Destroy(gameObject);
        }
    }

    private void OnGoldChanged(int newGold)
    {
        UpdateUI();
    }
    
    private void OnItemPurchased(ItemConfiguration purchasedItem)
    {
        UpdateUI();
    }
}

