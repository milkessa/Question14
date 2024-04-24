public class ValueTypeCollection<T> where T : struct
{
    private List<T> collection = new List<T>();

    public void AddItem(T item)
    {
        collection.Add(item);
    }

    public T GetItem(int index)
    {
        if (index >= 0 && index < collection.Count)
        {
            return collection[index];
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public List<T> GetSortedCollection()
    {
        return collection.OrderByDescending(x => x).ToList();
    }
}

