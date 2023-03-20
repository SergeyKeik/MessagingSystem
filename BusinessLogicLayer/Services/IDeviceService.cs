using BusinessLogicLayer.Dto;

namespace BusinessLogicLayer.Services;

public interface IDeviceService
{
    Task<DeviceDto> CreatePhoneAsync(Guid ownerId);
    Task<DeviceDto> CreateTelegramAsync(Guid ownerId);
    Task<DeviceDto> CreateEmailAsync(Guid ownerId);
    Task<MessageDto> SendMessageAsync(Guid sessionId, string contents, Guid deviceFromId, Guid deviceToId);
    Task<IReadOnlyCollection<MessageDto>> GetReceivedMessagesAsync(Guid sessionId, Guid deviceId);
    Task<MessageDto> MarkAsReadAsync(Guid sessionId, Guid messageId);
}