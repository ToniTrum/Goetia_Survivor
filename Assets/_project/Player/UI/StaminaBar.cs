using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Slider bar;
    [SerializeField] private TMP_Text StaminaText;

    public void Subscribe(PlayerModel model)
    {
        model.OnMaxStaminaChanged += UpdateMaxStamina;
        model.OnStaminaChanged += SetStamina;
    }

    public void Init(int maxStamina)
    {
        bar.maxValue = maxStamina;
        bar.value = maxStamina;
        UpdateTextStamina(maxStamina, maxStamina);
    }

    public void SetStamina(int stamina)
    {
        bar.value = stamina;
        UpdateTextStamina(stamina, (int)bar.maxValue);
    }

    public void UpdateMaxStamina(int maxStamina)
    {
        bar.maxValue = maxStamina;
        UpdateTextStamina((int)bar.value, maxStamina);
    }

    private void UpdateTextStamina(int current, int max)
    {
        StaminaText.text = $"{current} / {max}";
    }
}
