using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public static class DeviceMapping
{
    public static DeviceDto AsDto(this Device device)
        => new DeviceDto(device.Id, device.Owner.Id);
}