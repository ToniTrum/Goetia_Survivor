using System.Numerics;

public abstract class IPlayerState
{
    public PLayerStateType _stateType { get; protected set;}
    
    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }
    
    public virtual void Update()
    {
        
    }
    
    public virtual void HandleInput(Vector2 input)
    {
        
    }
    
}