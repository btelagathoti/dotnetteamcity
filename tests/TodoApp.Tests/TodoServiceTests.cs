using TodoApp.Models;
using TodoApp.Services;
using Xunit;

namespace TodoApp.Tests;
public class TodoServiceTests
{
    [Fact]
    public void AddAndGet_Item_ShouldMatch()
    {
        var svc = new TodoService();
        var item = new TodoItem { Title = "Test", IsDone = false };
        var added = svc.Add(item);
        Assert.Equal(1, added.Id);
        var got = svc.Get(added.Id);
        Assert.NotNull(got);
        Assert.Equal("Test", got!.Title);
    }

    [Fact]
    public void Remove_Item_ShouldReturnTrue()
    {
        var svc = new TodoService();
        var item = svc.Add(new TodoItem { Title = "ToRemove" });
        var removed = svc.Remove(item.Id);
        Assert.True(removed);
        Assert.Null(svc.Get(item.Id));
    }
}
