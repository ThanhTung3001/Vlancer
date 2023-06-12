using TSoft.TaskManagement.Application.Common.Exceptions;
using TSoft.TaskManagement.Application.TodoLists.Commands.CreateTodoList;
using TSoft.TaskManagement.Application.TodoLists.Commands.DeleteTodoList;
using TSoft.TaskManagement.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace TSoft.TaskManagement.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand { Title = "New List" });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}