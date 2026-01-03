using TodoApp.Models;
namespace TodoApp.Services;
public class TodoService
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;
    public IEnumerable<TodoItem> GetAll() => _items;
    public TodoItem? Get(int id) => _items.FirstOrDefault(i => i.Id == id);
    public TodoItem Add(TodoItem item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return item;
    }
    public bool Remove(int id) => _items.RemoveAll(i => i.Id == id) > 0;
}
