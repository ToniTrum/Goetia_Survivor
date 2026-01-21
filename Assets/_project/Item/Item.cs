using System;
using UnityEngine;
using Zenject;

public class Item
{
    ItemModel Model;

    public Item(ItemConfiguration itemConfiguration)
    {
        Model = new ItemModel(itemConfiguration.Id, itemConfiguration.name, itemConfiguration.Effect);
    }

    public void Apply(PlayerModel playerModel)
    {
        Model.Effect.Apply(playerModel);
    }

    public string GetId()
    {
        return Model.Id;
    }
}
