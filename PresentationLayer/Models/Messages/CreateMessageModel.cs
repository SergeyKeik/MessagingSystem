namespace PresentationLayer.Models.Accounts;

public record CreateMessageModel(Guid SessionId, string Contents, Guid DeviceFromId, Guid DeviceToId);