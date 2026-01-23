using UnityEngine;


[CreateAssetMenu(menuName = "Item Effects/Speed Boot")]
public class SpeedBootEffect : ItemEffect
{
    [SerializeField] private float SpeedIncreaseValue = 0.2f;

    public override void Apply(PlayerModel model)
    {
        model.Speed *= 1 + SpeedIncreaseValue;
    }

    public override string GetDescription()
    {
        return $"+{SpeedIncreaseValue*100}% к скорости";
    }
    
}
