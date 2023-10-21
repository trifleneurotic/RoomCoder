using Microsoft.AspNetCore.Components;
using RoomCoder.Application.Services;

namespace RoomCoder.Pages.Shared;

public partial class RoomCodeTable
{
    [Inject] public CurrentCodeNumbersService CurrentCodeNumbersService { get; set; }
    [Inject] public RoomCodesService RoomCodesService { get; set; }

    private Dictionary<byte, ushort> _roomCodes = new Dictionary<byte, ushort>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        foreach (var keyValuePair in CurrentCodeNumbersService.OrderedCurrentCodeNumbers)
        {
            _roomCodes.Add(keyValuePair.Key, RoomCodesService.GetRoomCode(keyValuePair.Key, keyValuePair.Value));
        }
    }
}