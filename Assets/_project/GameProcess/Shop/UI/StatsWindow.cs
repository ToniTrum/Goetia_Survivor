using TMPro;
using UnityEngine;
using Zenject;

public class StatsWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text MaxHealthText;
    [SerializeField] private TMP_Text SpeedText;
    [SerializeField] private TMP_Text DashSpeedText;

    [Inject] PlayerModel Model;

    private void Start()
    {
        MaxHealthText.text = Model.MaxHealth.ToString();
        SpeedText.text = Model.Speed.ToString();
        DashSpeedText.text = Model.DashSpeed.ToString();
    }

    public void Subscribe(PlayerModel model)
    {
        model.OnMaxHealthChanged += UpdateMaxHpText;
        model.OnSpeedChanged += UpdateSpeedText;
    }

    public void Unsubscribe(PlayerModel model)
    {
        model.OnMaxHealthChanged -= UpdateMaxHpText;
        model.OnSpeedChanged -= UpdateSpeedText;
    }

    public void UpdateMaxHpText(int value)
    {
        MaxHealthText.text = value.ToString();
    }

    public void UpdateSpeedText(float value)
    {
        SpeedText.text = value.ToString();
    }

    

}