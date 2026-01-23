using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopItemSlotView : MonoBehaviour
{
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemDescriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button buyButton;

    [SerializeField] private TMP_Text buyButtonText;

    private ItemConfiguration currentItem;
    private ShopPresenter presenter;

    [Inject] private PlayerModel playerModel;

    private bool isInitialized = false;
    private bool isOwned = false;
    private int slotIndex = -1;


    private void Start()
    {
        buyButton.onClick.AddListener(OnBuyClicked);

        playerModel.OnGoldChanged += OnGoldChanged;
        isInitialized = true;
        
        UpdateUI();
    }

    private void OnDestroy()
    {
        buyButton.onClick.RemoveAllListeners();
    }

    public void SetPresenter(ShopPresenter shopPresenter)
    {
        presenter = shopPresenter;
    }

    public void SetItem(ItemConfiguration item)
    {
        currentItem = item;
        isOwned = false;
        
        if (currentItem == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        gameObject.SetActive(true);
        
        
        itemNameText.text = currentItem.Name;
        itemImage.sprite = currentItem.ItemImage;
        costText.text = currentItem.Cost.ToString();
        itemDescriptionText.text = currentItem.Effect?.GetDescription() ?? "";
        buyButtonText.text = "BUY"; 
        buyButtonText.color = Color.black;
        
        
        if (isInitialized)
        {
            UpdateUI();
        }
    }

    public void SetSlotIndex(int index)
    {
        slotIndex = index;
    }

    public void UpdateUI()
    {
        if(!isInitialized || currentItem == null || presenter == null)
            return;

        if (isOwned)
        {
            buyButton.interactable = false;
            buyButtonText.text = "OWNED";
            buyButtonText.color = Color.gray;
            costText.color = Color.green;
        }
        else
        {
            bool canBuy = presenter.Model.CanBuyItem(currentItem);
            buyButton.interactable = canBuy;
            costText.color = canBuy ? Color.white : Color.red;   
            buyButtonText.text = "BUY"; 
        }
        
    }

    private void OnBuyClicked()
    {
        if(currentItem == null || presenter == null)
            return;
        
        presenter.OnBuyItemClicked(currentItem, slotIndex);
    }

    private void OnGoldChanged(int newGoldValue)
    {
        UpdateUI();
    }

    public void MarkAsPurchased()
    {
        isOwned = true;
        UpdateUI();
    }

    public void MarkAsPurchasedIfMathces(ItemConfiguration item)
    {
        if(currentItem == item)
        {
            MarkAsPurchased();
        }
    }

}