using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider bar;
    [SerializeField] private TMP_Text HpText;

    public void Subscribe(PlayerModel model)
    {
        model.OnMaxHealthChanged += UpdateMaxHp;
        model.OnHealthChanged += SetHealth;

        Init(model.MaxHealth);
        SetHealth(model.Health);
    }

    public void Init(int maxHealth)
    {
        bar.maxValue = maxHealth;
        bar.value = maxHealth;
        UpdateTextHp(maxHealth, maxHealth);
    }

    public void SetHealth(int health)
    {
        
        bar.value = health;
        UpdateTextHp(health, (int)bar.maxValue);
    }

    public void UpdateMaxHp(int maxHp)
    {
        bar.maxValue = maxHp;
        UpdateTextHp((int)bar.value, maxHp);
    }

    private void UpdateTextHp(int current, int max)
    {
        HpText.text = $"{current} / {max}";
    }
}