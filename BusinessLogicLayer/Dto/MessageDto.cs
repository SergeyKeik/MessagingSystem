namespace BusinessLogicLayer.Dto;

public record MessageDto(
    Guid Id, string Contents, Guid DeviceFrom, Guid DeviceTo, DateTime Date);