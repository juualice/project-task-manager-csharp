namespace TaskManager.Application.DTOs;

public record ProjectDto(int Id, string Name, string? Description, DateTime CreatedAt);

public record CreateProjectDto(string Name, string? Description);

public record UpdateProjectDto(string Name, string? Description);