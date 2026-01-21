using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text ItemName;
    [SerializeField] private Image ItemImage;
    [SerializeField] private TMP_Text ItemDescription;
    [SerializeField] private TMP_Text Cost;
    [SerializeField] private Button BuyButton;
    [SerializeField] private ItemConfiguration Item;

    [Inject] private ShopService shopService;
    
    private void Start()
    {

        if (shopService == null)
        {
            Debug.LogError("ShopService is null! Check Zenject bindings.", this);
            return;
        }
        BuyButton.onClick.AddListener(OnBuyButtonClicked);
        Init();
    }

    public void OnDestroy()
    {
        BuyButton.onClick.RemoveAllListeners();
    }

    private void OnEnable()
    {
        UpdateUI();        
    }

    private void Init()
    {
        if(Item == null) return;

        ItemName.text = Item.Name;
        ItemImage.sprite = Item.ItemImage;
        Cost.text = Item.Cost.ToString();
        ItemDescription.text = Item.Effect.GetDescription() ?? "";
    }

    private void UpdateUI()
    {
        bool CanBuyItem = shopService.CanBuyItem(Item);
        BuyButton.interactable = CanBuyItem;
        Cost.color = CanBuyItem ? Color.white : Color.gray;
    }

    public void OnBuyButtonClicked()
    {
        if(shopService.TryBuyItem(Item))
        {
            Debug.Log($"Куплен предмет: {Item.Name}");
            Destroy(this);
            UpdateUI();
        }
        else
        {
            Debug.Log("Недостаточно Золота");
        }
    }

    
}
