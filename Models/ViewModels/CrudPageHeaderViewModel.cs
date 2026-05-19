namespace CRUD.Models.ViewModels;

/// <summary>Botón opcional a la derecha del encabezado (p. ej. Editar en vistas de detalle).</summary>
public sealed class CrudHeaderActionLink
{
    public required string ActionName { get; init; }
    public string? ControllerName { get; init; }
    public required string Text { get; init; }
    public string IconClass { get; init; } = "fa-pen-to-square";
    public int EntityId { get; init; }
    public string ButtonClass { get; init; } = "btn btn-warning btn-lg";
}

public sealed class CrudPageHeaderViewModel
{
    public required string Title { get; init; }
    public string? Subtitle { get; init; }
    public string IconClass { get; init; } = "fa-folder";
    public string BackAction { get; init; } = "Index";
    public string? BackController { get; init; }
    public bool TitleDanger { get; init; }
    public CrudHeaderActionLink? SecondaryAction { get; init; }
}
