
using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Living Medal")]
public class LivingMedalEffect : ItemEffect
{
    [SerializeField] private int HealthValue = 12;
    public override void Apply(PlayerModel model)
    {
        model.MaxHealth += HealthValue;
        model.Health += HealthValue;
    }

    public override string GetDescription()
    {
        return $"+{HealthValue} к максимальному здоровью";
    }
}