using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public static class MessageMapping
{
    public static MessageDto AsDto(this Message message)
        => new MessageDto(message.Id, message.Contents, message.DeviceFrom.Id, message.DeviceTo.Id, message.Date);
    
}