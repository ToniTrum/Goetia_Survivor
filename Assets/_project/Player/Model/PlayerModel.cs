public class PlayerModel
{
    
    private int _maxHealth { get; set; }
    private int _maxStamina { get; set; }
    private float _speed { get; set; }
    private int _health;
    private int _stamina;
    private PLayerStateType _state;

    public PlayerModel(float speed)
    {
        _speed = speed;
    }
    
    public int GetHealth()
    {
        return _health;
    }

    public int GetStamina()
    {
        return _stamina;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetHealth(int health)
    {
        _health = health;
    }

    public void SetStamina(int stamina)
    {
        
    }
    
    public void SetState(PLayerStateType state)
    {
        _state = state;
    }
}