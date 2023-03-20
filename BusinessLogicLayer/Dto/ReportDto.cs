namespace BusinessLogicLayer.Dto;

public record ReportDto(Guid Id, Guid Supervisor, IEnumerable<Guid> ReportInfosIds);