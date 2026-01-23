using UnityEngine;


[CreateAssetMenu(menuName = "Item Effects/Angel Bracelet")]
public class AngelBraceletEffect : ItemEffect
{
    [SerializeField] private float MaxHealthPercentageValue = 0.05f;

    public override void Apply(PlayerModel model)
    {
        model.MaxHealth = (int)(model.MaxHealth *MaxHealthPercentageValue * 100);        
    }

    public override string GetDescription()
    {
        return $"+ {MaxHealthPercentageValue * 100}% к максимальному здоровью";
    }
}
