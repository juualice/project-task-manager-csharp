namespace TaskManager.Application.DTOs;

public record TaskDto(int Id, string Title, string? Description, 
    TaskManager.Domain.Enums.TaskStatus Status, 
    TaskManager.Domain.Enums.TaskPriority Priority, 
    int ProjectId, DateTime CreatedAt);

public record CreateTaskDto(string Title, string? Description, 
    TaskManager.Domain.Enums.TaskPriority Priority, int ProjectId);

public record UpdateTaskDto(string Title, string? Description, 
    TaskManager.Domain.Enums.TaskPriority Priority);

public record UpdateTaskStatusDto(TaskManager.Domain.Enums.TaskStatus Status);