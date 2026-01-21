public class ItemModel
{
    public string Id { get; }
    public string Name { get; }
    public ItemEffect Effect { get; }

    public ItemModel(string id, string name, ItemEffect effect)
    {
        Id = id;
        Name = name;
        Effect = effect;
    }
}