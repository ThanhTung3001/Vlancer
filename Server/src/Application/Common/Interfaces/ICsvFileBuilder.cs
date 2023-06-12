using TSoft.TaskManagement.Application.TodoLists.Queries.ExportTodos;

namespace TSoft.TaskManagement.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}