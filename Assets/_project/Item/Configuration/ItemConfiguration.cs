using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfiguration", menuName = "Scriptable Objects/ItemConfiguration")]
public class ItemConfiguration : ScriptableObject
{
    public String Id;
    public String Name;
    public Sprite ItemImage;
    public int Cost;
    public ItemEffect Effect;
}
