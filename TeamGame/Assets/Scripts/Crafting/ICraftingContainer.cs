public interface ICraftingContainer
{
    int ItemCounter(ItemDatabase item);
    bool ContainsItems(ItemDatabase item);
    bool RemoveItems(ItemDatabase item);
    bool AddItems(ItemDatabase item);
}
