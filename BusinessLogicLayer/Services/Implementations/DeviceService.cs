using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Exceptions.AuthorizationException;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.Implementations;

public class DeviceService : IDeviceService
{
    private readonly DatabaseContext _context;

    public DeviceService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<DeviceDto> CreatePhoneAsync(Guid ownerId)
    {
        var owner = await _context.Accounts.FindAsync(ownerId);
        var device = new Phone(Guid.NewGuid(), owner);

        _context.Devices.Add(device);
        await _context.SaveChangesAsync();

        return device.AsDto();
    }

    public async Task<DeviceDto> CreateTelegramAsync(Guid ownerId)
    {
        var owner = await _context.Accounts.FindAsync(ownerId);
        var device = new Telegram(Guid.NewGuid(), owner);

        _context.Devices.Add(device);
        await _context.SaveChangesAsync();

        return device.AsDto();
    }

    public async Task<DeviceDto> CreateEmailAsync(Guid ownerId)
    {
        var owner = await _context.Accounts.FindAsync(ownerId);
        var device = new Email(Guid.NewGuid(), owner);

        _context.Devices.Add(device);
        await _context.SaveChangesAsync();

        return device.AsDto();
    }

    public async Task<MessageDto> SendMessageAsync(Guid sessionId, string contents, Guid deviceFromId, Guid deviceToId)
    {
        var deviceFrom = await _context.Devices.GetEntityAsync(deviceFromId);
        var deviceTo = await _context.Devices.GetEntityAsync(deviceToId);
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        if (session.AccountId != deviceFrom.Owner.Id)
        {
            throw new OperationIsNotAuthorizedException("No access to this device");
        }
        if (deviceFrom.Owner.Department.Id != deviceTo.Owner.Department.Id)
        {
            throw new OperationIsNotAuthorizedException("Wrong department");
        }
        var message = new Message(Guid.NewGuid(), contents, deviceFrom, deviceTo, DateTime.Now);
        _context.Messages.Add(message);
        deviceFrom.Sent.Add(message);
        deviceTo.Received.Add(message);
        _context.Update(deviceFrom);
        _context.Update(deviceTo);
        await _context.SaveChangesAsync();

        return message.AsDto();
    }

    public async Task<IReadOnlyCollection<MessageDto>> GetReceivedMessagesAsync(Guid sessionId, Guid deviceId)
    {
        var device = await _context.Devices.GetEntityAsync(deviceId);
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        if (session.AccountId != device.Owner.Id)
        {
            throw new OperationIsNotAuthorizedException("No access to this device");
        }
        foreach (var message in device.Received)
        {
            if (message.MessageStatus != Message.Status.Read)
            {
                message.MessageStatus = Message.Status.Received;

                _context.Messages.Update(message);
            }
        }

        await _context.SaveChangesAsync();
        IReadOnlyCollection<MessageDto> messageDtos = device.Received.Select(x => x.AsDto()).ToList();
        return messageDtos;
    }

    public async Task<MessageDto> MarkAsReadAsync(Guid sessionId, Guid messageId)
    {
        var message = await _context.Messages.GetEntityAsync(messageId);
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        if (session.AccountId != message.DeviceTo.Owner.Id)
        {
            throw new OperationIsNotAuthorizedException("No access to this device");
        }
        message.MessageStatus = Message.Status.Read;
        message.Processed = true;

        _context.Messages.Update(message);
        await _context.SaveChangesAsync();

        return message.AsDto();
    }
}