using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopConfiguration", menuName = "Scriptable Objects/ShopConfiguration")]
public class ShopConfiguration : ScriptableObject
{
    public int SlotCount = 3;

    public int RefreshCost = 10;

    public List<ItemConfiguration> AvaliableItems = new List<ItemConfiguration>();

}
