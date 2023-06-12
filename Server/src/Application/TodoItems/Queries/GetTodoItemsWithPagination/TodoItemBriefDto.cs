using TSoft.TaskManagement.Application.Common.Mappings;
using TSoft.TaskManagement.Domain.Entities;

namespace TSoft.TaskManagement.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}