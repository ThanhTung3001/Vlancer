using TSoft.TaskManagement.Application.Common.Mappings;
using TSoft.TaskManagement.Domain.Entities;

namespace TSoft.TaskManagement.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}