using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class ProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _repository.GetAllAsync();
        return projects.Select(p => new ProjectDto(p.Id, p.Name, p.Description, p.CreatedAt));
    }

    public async Task<ProjectDto?> GetByIdAsync(int id)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null) return null;
        return new ProjectDto(project.Id, project.Name, project.Description, project.CreatedAt);
    }

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
    {
        var project = new Project { Name = dto.Name, Description = dto.Description };
        var created = await _repository.CreateAsync(project);
        return new ProjectDto(created.Id, created.Name, created.Description, created.CreatedAt);
    }

    public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null) return null;
        project.Name = dto.Name;
        project.Description = dto.Description;
        var updated = await _repository.UpdateAsync(project);
        return new ProjectDto(updated.Id, updated.Name, updated.Description, updated.CreatedAt);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null) return false;
        await _repository.DeleteAsync(id);
        return true;
    }
}