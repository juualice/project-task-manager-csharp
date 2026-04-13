using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class TaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskDto>> GetByProjectIdAsync(int projectId)
    {
        var tasks = await _repository.GetByProjectIdAsync(projectId);
        return tasks.Select(t => new TaskDto(t.Id, t.Title, t.Description, t.Status, t.Priority, t.ProjectId, t.CreatedAt));
    }

    public async Task<TaskDto?> GetByIdAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;
        return new TaskDto(task.Id, task.Title, task.Description, task.Status, task.Priority, task.ProjectId, task.CreatedAt);
    }

    public async Task<TaskDto> CreateAsync(CreateTaskDto dto)
    {
        var task = new TaskItem { Title = dto.Title, Description = dto.Description, Priority = dto.Priority, ProjectId = dto.ProjectId };
        var created = await _repository.CreateAsync(task);
        return new TaskDto(created.Id, created.Title, created.Description, created.Status, created.Priority, created.ProjectId, created.CreatedAt);
    }

    public async Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto dto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;
        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Priority = dto.Priority;
        var updated = await _repository.UpdateAsync(task);
        return new TaskDto(updated.Id, updated.Title, updated.Description, updated.Status, updated.Priority, updated.ProjectId, updated.CreatedAt);
    }

    public async Task<TaskDto?> UpdateStatusAsync(int id, UpdateTaskStatusDto dto)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return null;
        task.Status = dto.Status;
        var updated = await _repository.UpdateAsync(task);
        return new TaskDto(updated.Id, updated.Title, updated.Description, updated.Status, updated.Priority, updated.ProjectId, updated.CreatedAt);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return false;
        await _repository.DeleteAsync(id);
        return true;
}
}