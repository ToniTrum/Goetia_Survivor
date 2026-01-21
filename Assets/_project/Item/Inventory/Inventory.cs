using System.Collections.Generic;

public class Inventory
{
    private List<Item> items = new();
    public IReadOnlyList<Item> Items => items;


    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public bool HasItem(string itemId)
    {
        return items.Exists(item => item.GetId() == itemId);
    }
}