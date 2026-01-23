using TMPro;
using UnityEngine;

public class GoldBar : MonoBehaviour
{
    [SerializeField] private TMP_Text GoldText;

    public void Subscribe(PlayerModel model)
    {
        model.OnGoldChanged += UpdateText;
        UpdateText(model.Gold);
    }

    public void Unsubscribe(PlayerModel model)
    {
        model.OnGoldChanged -= UpdateText;
    }

    public void UpdateText(int value)
    {
        GoldText.text = value.ToString();
    }

}
