using UnityEngine;

public class PlayerHandProxy : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponentInParent<Player>();
    }

    public void OnAttackAnimationComplete()
    {
        StartCoroutine(_player.OnAttackAnimationComplete());
    }

}