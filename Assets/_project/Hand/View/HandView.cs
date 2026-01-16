using UnityEngine;

public abstract class HandView
{
    public void AimIt(Vector3 target) { }
    public void Idle() { }
    public void Walk() { }
    public void Attack() { }

    public void EnableSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = true;
    }

    public void DisableSprite(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.enabled = false;
    }
}

